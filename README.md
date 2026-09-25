# IQ Puzzle

A Unity recreation of the "IQ Puzzler" style tabletop game: fit 12 coloured
bead-shaped pieces onto an 11 x 5 board. Each level pre-places some pieces;
the player drags, rotates and flips the rest until all 55 cells are filled.

## Open / run

- Unity **2020.3.11f1** (see `ProjectSettings/ProjectVersion.txt`). Open the
  folder in Unity Hub; the `Library/` cache is regenerated on first import.
- Start scene: `Assets/Scenes/StartScreen.unity`. Other scenes:
  `2DLevels` (level select), `2DMain` (the board), `Info`.
- Controls (editor / desktop): click a piece to select it, hold and drag to
  move it, click it again to deselect; the on-screen Rotate / Flip buttons act
  on the selected piece. the finish button validates the board; "Hint" places one piece.

## Code map (`Assets/Scripts`)

| Script | Role |
|---|---|
| `Levels.cs` | Level data: per-piece position/rotation; `|x| >= 10` marks a piece the player must place |
| `LayoutManager.cs` | Places the fixed pieces for the current level (`PlayerPrefs currentLevel`) |
| `TouchDetector.cs` | Mouse selection, drag, rotate/flip of pieces |
| `PieceScript.cs` | Grid snapping (0.2 units), rotation snapping, outline highlight |
| `FinishChecker.cs` | Raycasts the 55 cells; records finished levels in `PlayerPrefs` |
| `Main.cs` | Hint button |

## Test

There is no automated test suite yet. Smoke test: open `StartScreen`, press
Play, pick level 1, drag a piece, rotate/flip it, press Hint and Check.
The Unity Test Framework package is already installed if EditMode tests are
added later.
