# IQ Puzzle roadmap

## Current state (2026-09-25)

What works, as far as reading the code and a compile check can tell:

- Unity **2020.3.11f1** project (`ProjectSettings/ProjectVersion.txt`). Four
  scenes are in the build list (`ProjectSettings/EditorBuildSettings.asset`):
  `StartScreen` -> `2DLevels` (level select) -> `2DMain` (board) and `Info`.
  A fifth scene, `Assets/Scenes/Layout Testing.unity`, is not in the build.
- **24 levels** are defined in `Assets/Scripts/Levels.cs` (`//1` .. `//24`),
  each as four 12-entry lists (`posx`, `posy`, `rotx`, `roty`, one entry per
  piece). A value with `|v| >= 10` marks a piece the player must place; the
  remainder mod 10 is its solved position, which `Main.GenerateHint()` uses.
- **Mouse play** (`TouchDetector.cs`, `Update()`): click a piece to select and
  outline it (QuickOutline), hold to drag, click it again to deselect; the
  Rotate / Flip UI buttons call `TouchDetector.Rotate()` / `Flip()` on the
  selected piece. `PieceScript` snaps position to a 0.2 grid and rotation to
  90 / 180 degree steps every frame and clamps Y to `[5.1, 5.4]`.
- **Finish check** (`FinishChecker.CheckFinish()`): raycasts the 55 cells of
  the 11 x 5 board from `y = 5.4` downwards; on 55 hits it appends the level
  to the `levelsFinished` JSON list in `PlayerPrefs` and loads `2DLevels`.
- **Level select** (`ButtonScript`): buttons named `LevelButton.N` load level
  N into `PlayerPrefs currentLevel`; buttons beyond `Levels.posx.Count` are
  destroyed; finished levels are recoloured. `Reset.ResetAll()` wipes prefs.

How that was verified today:

- Commit `c042e17` (2026-09-25) fixed selection / highlight / hint / finish
  bugs by code reading; the fixes have **not** been run in the editor.
  2020.3.11f1 is not installed on this machine (only 6000.1.4f1 and
  6000.3.1f1 are), and the project was deliberately not opened in Unity 6 to
  avoid an unreviewed upgrade of `ProjectSettings/` and `Library/`.
- All nine gameplay scripts plus `QuickOutline/Scripts/Outline.cs` compile
  with Roslyn `csc` (Mono 6.12) against the Unity 6000.3.1f1 engine
  assemblies, the project's cached `Unity.TextMeshPro.dll` /
  `UnityEngine.UI.dll` and the netstandard 2.1 facade: 0 errors (the command
  is in `README.md` under *Test*). This is a syntax / type check only.
- Last editor-side build evidence is `Library/ScriptAssemblies/Assembly-CSharp.dll`
  dated 2024-01-31, i.e. from before today's fixes.
- There are **no automated tests**.

## Known gaps and bugs

- **No touch input.** The touchscreen path in `TouchDetector.cs` is ~230
  lines of commented-out code (two abandoned versions, plus a `Two2Three`
  function written in Python syntax). Phones only work if Unity's default
  `Input.simulateMouseWithTouches` covers single-finger drag; unverified.
- **`Levels.drag` is declared and documented but never populated or read**
  (`Levels.cs`, the "The number '1' in the 'drag' list" comment). Draggability
  actually comes from `|posx| >= 10` in `LayoutManager.SetupPositions()`.
- **`Levels.Initialize()` runs up to three times per scene**: from the
  `Instance` getter, from `Start()`, and again from `LayoutManager.Start()`.
  Harmless (lists are cleared first) but wasteful and confusing.
- **`FinishedLevelsClass` is duplicated** verbatim in `FinishChecker.cs` and
  `ButtonScript.cs`, as is the `PlayerPrefs` JSON read.
- **Finished-level colour is wrong**: `ButtonScript.Start()` uses
  `new Color(0f, 170f, 255f, 255f)`; `Color` takes 0..1 floats, so this
  renders as cyan, not the intended `(0, 170, 255)` blue. Use `Color32`.
- **`ButtonScript.Start()` keeps running after `Destroy(this.gameObject)`**
  for buttons past the last level (missing `return`); safe only because
  `Destroy` is deferred.
- **`ButtonScript.Update()`** resizes the scroll content every frame for the
  level-1 button, and `RemoveBlankScreens()` walks a hard-coded
  `parent.parent.parent.parent` chain.
- **Hint is one-shot**: `Main.GenerateHint()` hides the button after the first
  hint and mutates the level lists in place (`%= 10`). Intentional? See
  open questions.
- **Dead code**: `PieceScript.isDragging` is never set; `using
  UnityEngine.UIElements` in `TouchDetector.cs` is unused; empty `Update()`
  bodies in `LayoutManager`, `FinishChecker`, `Main`, `SceneManager`.
- **`SceneManager` class shadows `UnityEngine.SceneManagement.SceneManager`**,
  which is why every caller spells out the full namespace.
- **No linting or pre-commit hooks** for C#; no `.editorconfig`.
- **No CI**: nothing builds or tests the project on push.

## Milestones

### 1. Prove it runs

- [ ] Install Unity 2020.3.11f1 through Unity Hub, or decide to upgrade (see
      open questions) and commit the upgraded `ProjectSettings/` in its own
      commit.
- [ ] Open the project, confirm the console shows 0 errors after import.
- [ ] Play `StartScreen` -> level 1 -> drag, rotate, flip, hint, finish.
- [ ] Fix whatever the 2026-09-25 fixes broke at runtime, if anything.

**Done when:** `docs/level1-finished.png` (a Play-mode screenshot of level 1
completing and returning to `2DLevels` with the button recoloured) is committed,
and the editor log shows zero compile errors.

### 2. EditMode tests and CI

- [ ] Add `Assets/Tests/EditMode/` with an asmdef referencing
      `Assembly-CSharp` (Test Framework 1.1.24 is already in
      `Packages/manifest.json`).
- [ ] Tests for `PieceScript.RoundPosition` / `RoundRotation` (grid and
      rotation snapping, including negative values).
- [ ] Tests over `Levels`: 24 levels, every list has 12 entries, every level
      has at least one `|v| >= 10` piece, and no two fixed pieces share a
      solved position.
- [ ] Test that `FinishedLevelsClass` JSON round-trips and does not duplicate
      a level.
- [ ] GitHub Actions workflow running `Unity -batchmode -runTests
      -testPlatform EditMode` (e.g. `game-ci/unity-test-runner`).

**Done when:** the EditMode run passes in CI on `main` and the README shows
the workflow badge.

### 3. Clean up the scripts

- [ ] Delete the commented-out touch and `Two2Three` blocks in
      `TouchDetector.cs`.
- [ ] Remove `Levels.drag` and its comment, `PieceScript.isDragging`, the
      unused `using`, and the empty `Update()` methods.
- [ ] Move `FinishedLevelsClass` and the `PlayerPrefs` read / write into one
      static `SaveData` helper used by `FinishChecker` and `ButtonScript`.
- [ ] Rename `SceneManager` to `SceneLoader`; fix the `Color` -> `Color32`
      bug; add the missing `return` after `Destroy` in `ButtonScript`.
- [ ] Add `.editorconfig` and a `dotnet format --verify-no-changes`
      pre-commit hook.

**Done when:** milestone 2 tests still pass, `dotnet format` reports no
changes, and a level-1 play-through screenshot is refreshed in `docs/`.

### 4. Touch input

- [ ] Decide: legacy `Input` with `simulateMouseWithTouches`, or the Input
      System package.
- [ ] Verify single-finger select / drag / deselect on a phone build or the
      Device Simulator; port the old touch path onto `HandlePress` /
      `DragSelected` only if the simulation is not enough.
- [ ] Add the mobile build target and its icon / orientation settings.

**Done when:** a screen recording (`docs/touch-level1.mp4`) shows level 1
solved by touch on a device or the Device Simulator.

### 5. Ship a playable build

- [ ] GitHub Actions build for WebGL (and macOS standalone).
- [ ] Publish the WebGL build to GitHub Pages or itch.io.
- [ ] README links to the live build.

**Done when:** a public URL loads the game and level 1 can be finished in a
browser.

## Won't do / out of scope

- A 3D / pyramid mode. Scene names say `2D` and `ButtonScript.LoadLevel()`
  has an empty branch for a future mode; not planned.
- Replacing QuickOutline or TextMesh Pro, or rewriting on the new Input
  System unless milestone 4 needs it.
- Accounts, cloud save, leaderboards. `PlayerPrefs` is enough.
- A level generator or levels beyond the 24 in `Levels.cs`.

## Open questions for the owner

1. Stay on 2020.3.11f1 (must be installed) or upgrade to a Unity 6 LTS that
   is already on this machine? The upgrade rewrites `ProjectSettings/` and
   may need TMP resources re-imported.
2. Is the target platform phones (the touch code suggests so) or desktop?
   That decides whether milestone 4 comes before milestone 5.
3. Is `Assets/Scenes/Layout Testing.unity` still needed, or can it go?
4. The GitHub repo is public and vendors QuickOutline (its `Readme.txt`
   carries no license text) and the TextMesh Pro examples. Is that fine, or
   should a license note be added and the TMP `Examples & Extras` folder be
   dropped?
5. Should the hint stay one-per-level-load, or become repeatable?
6. `origin/main` had a commit `3a024ca` ("Final commit before wiping and
   repurposing old mac") that only touched `TouchDetector.cs` (an earlier
   version of the toggle-deselect fix) and generated IDE files. It was merged
   with the local rewrite kept. Is anything else from the old Mac missing?
