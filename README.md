# IQ Puzzle

A Unity recreation of the "IQ Puzzler" style tabletop game: fit 12 coloured
bead-shaped pieces onto an 11 x 5 board. Each of the 24 levels pre-places some
pieces; the player drags, rotates and flips the rest until all 55 cells are
filled.

**Status: experimental.** The scripts compile, but the 2026-09-25 bug fixes
have not yet been run in the Unity editor (see [ROADMAP.md](ROADMAP.md)).

## Install

- Unity Hub with **Unity 2020.3.11f1** (`ProjectSettings/ProjectVersion.txt`).
  Opening the project in a newer editor will upgrade it; do that on purpose,
  in its own commit.
- Clone the repo and add the folder in Unity Hub. `Library/` is regenerated
  on first import (a few minutes).

## Configure

There is nothing to configure: no env vars, no `.env`, no services. Progress
lives in `PlayerPrefs` (`currentLevel`, `levelsFinished`); the in-game Reset
button clears it.

## Run

Open `Assets/Scenes/StartScreen.unity` and press Play. Scene flow:
`StartScreen` -> `2DLevels` (level select) -> `2DMain` (the board); `Info`
is the help screen.

Controls (mouse): click a piece to select it, hold and drag to move it, click
it again to deselect. The Rotate / Flip buttons act on the selected piece,
Hint places one unplaced piece, and Check validates the board. Touch input is
not wired up yet.

## Code map (`Assets/Scripts`)

| Script | Role |
|---|---|
| `Levels.cs` | Level data for levels 1-24: per-piece position and rotation; `\|v\| >= 10` marks a piece the player must place |
| `LayoutManager.cs` | Places the fixed pieces for the current level (`PlayerPrefs currentLevel`) |
| `TouchDetector.cs` | Mouse selection, drag, rotate / flip of pieces |
| `PieceScript.cs` | Grid snapping (0.2 units), rotation snapping, outline highlight |
| `FinishChecker.cs` | Raycasts the 55 cells; records finished levels in `PlayerPrefs` |
| `Main.cs` | Hint button |
| `ButtonScript.cs` | Level-select buttons: load a level, colour finished ones |
| `SceneManager.cs` | Thin scene-loading wrapper used by UI buttons |
| `Reset.cs` | Clears `PlayerPrefs` |

`Assets/QuickOutline/` is the third-party outline effect used for selection.

## Test

There is no automated test suite yet (the Unity Test Framework package is
installed; adding EditMode tests is roadmap milestone 2).

Two checks are available today:

- **Compile check without opening the editor** (needs Mono's `csc` and any
  Unity install for its engine assemblies; adjust the version path):

  ```sh
  M=/Applications/Unity/Hub/Editor/6000.3.1f1/Unity.app/Contents/Resources/Scripting/Managed/UnityEngine
  NS=/Applications/Unity/Hub/Editor/6000.3.1f1/Unity.app/Contents/Resources/Scripting/NetStandard/ref/2.1.0/netstandard.dll
  csc -nologo -nostdlib -noconfig -target:library -out:/tmp/IQPuzzle-check.dll \
    -r:$NS -r:$M/UnityEngine.dll -r:$M/UnityEngine.CoreModule.dll \
    -r:$M/UnityEngine.PhysicsModule.dll -r:$M/UnityEngine.UIModule.dll \
    -r:$M/UnityEngine.UIElementsModule.dll -r:$M/UnityEngine.JSONSerializeModule.dll \
    -r:$M/UnityEngine.InputLegacyModule.dll \
    -r:Library/ScriptAssemblies/Unity.TextMeshPro.dll -r:Library/ScriptAssemblies/UnityEngine.UI.dll \
    Assets/Scripts/*.cs Assets/QuickOutline/Scripts/Outline.cs
  ```

- **Smoke test in the editor:** open `StartScreen`, press Play, pick level 1,
  drag a piece, rotate and flip it, press Hint, then Check.

## Roadmap

See [ROADMAP.md](ROADMAP.md) for current state, known bugs, milestones and
open questions.
