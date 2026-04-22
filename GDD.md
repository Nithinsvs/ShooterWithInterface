# Space Shooter - Game Design Document (GDD)

## 1) Game Overview

**Working Title:** Space Shooter  
**Genre:** 2D Top-Down Arcade Shooter  
**Engine:** Unity (2D)  
**Platform (Current):** PC (Keyboard + Mouse)  
**Project Status:** Prototype / Early Vertical Slice

### High Concept
The player pilots a ship inside a bounded arena, destroys descending enemies, and builds score over time. The game includes a save system for progression and an in-progress shop system intended to support upgrades or item purchases.

### Core Pillars
- **Simple, responsive controls** for immediate action.
- **Short, replayable sessions** focused on score chasing.
- **Steady challenge pressure** through enemy spawns.
- **Persistent progression** via save data and future shop upgrades.

---

## 2) Target Audience

- Players who enjoy quick arcade gameplay loops.
- Casual to mid-core players looking for short sessions.
- Developers/students using the project as a learning prototype for Unity architecture (events, pooling, save/load).

---

## 3) Core Gameplay Loop

1. Start game and load previous player data (score persistence).
2. Control player movement in arena bounds.
3. Shoot bullets to destroy enemies.
4. Gain score from enemy eliminations.
5. Survive while enemies continue spawning.
6. Save updated score as progression.
7. Optional: spend currency/amount in shop (feature framework present, balancing pending).

---

## 4) Player Experience Goals

- Controls feel quick and predictable.
- Constant action with little downtime.
- Clear feedback for score growth and success.
- Motivation to replay and beat previous score.
- Eventual long-term progression through purchasable upgrades.

---

## 5) Controls (Current)

- **Move:** `WASD` / Arrow keys (Unity Horizontal/Vertical axes).
- **Shoot:** Left mouse button or `Space`.

---

## 6) Game Systems

## 6.1 Player
- Player moves via Rigidbody2D-based position updates.
- Movement is clamped to arena bounds (`x: -5 to 5`, `y: -5 to 5` in current implementation).
- Uses a bullet pool to reduce runtime instantiation overhead.
- Player state enum exists (`Normal`, `Shooting`, `Dead`), currently used mainly for state tracking/logging.

## 6.2 Combat
- On fire input, a pooled bullet is activated at player position.
- Bullets auto-return to pool after a lifetime timer.
- Enemy collisions with bullet deactivate bullet and kill enemy.

## 6.3 Enemies
- Enemies spawn at top of play area at random horizontal positions.
- Enemy manager preloads a pool of enemy objects and reuses them after death.
- Enemy movement is downward over time.
- Enemy can die from:
  - **Player kill** (awards score).
  - **Timeout** (no score award).

## 6.4 Scoring
- Each enemy provides a score value on player kill.
- Score updates are broadcast to UI via event.
- Score is persisted to disk through save/load flow.

## 6.5 UI
- Current score is displayed in UI text.
- Shop UI supports listing items with icon + price and buy button hooks.

## 6.6 Save/Load
- Save data includes score (and placeholder health field).
- Data is serialized as JSON and stored in persistent data path.
- On startup, saved data is loaded and score initialized.

## 6.7 Shop (In Progress)
- Shop items are ScriptableObjects with `itemName`, `icon`, `price`.
- Shop supports purchase checks against a current amount.
- Item delivery effect currently placeholder (log/event path, no gameplay effect yet).

---

## 7) Progression & Economy (Design Direction)

### Current
- Persistent score exists and can serve as meta-currency foundation.

### Proposed
- Use score or separate currency to buy permanent upgrades:
  - Fire rate increase
  - Bullet damage increase
  - Max health increase
  - Temporary shield / revive
- Add unlock tiers so players have medium-term goals.

---

## 8) Game States (Proposed Full Flow)

- **Main Menu**
- **Gameplay (Active)**
- **Pause**
- **Game Over**
- **Shop**
- **Results / High Score**

Current project appears centered on direct scene gameplay with systems for score and shop already integrated.

---

## 9) Win/Lose Conditions

### Current Behavior
- Core loop supports continuous survival and score gain.
- Player deactivation on enemy collision indicates loss behavior path, but full game-over loop can be expanded.

### Proposed Final Rules
- **Lose:** Player health reaches 0 (or collision death if one-hit mode).
- **Win:** Endless score attack (no hard win), with milestones/achievements.

---

## 10) Content Plan

## 10.1 Enemy Types
- **Implemented direction:** random enemy prefab factory supports multiple enemy prefabs.
- **Planned expansion:**
  - Basic slow enemy
  - Fast weak enemy
  - Tank enemy (high HP, high score)
  - Shooter enemy (returns fire)

## 10.2 Weapons/Upgrades
- Basic projectile shot (implemented).
- Multi-shot / spread shot.
- Piercing bullets.
- Cooldown reduction.

## 10.3 Shop Items
- Consumables: heal, shield, bomb.
- Permanent upgrades: damage, fire rate, move speed.

---

## 11) Technical Notes

- Architecture uses event-driven communication (`GameEvents`, score events).
- Object pooling used for bullets and enemies.
- Save pipeline implemented via JSON utility.
- Namespace usage is mostly consistent; recommended to standardize all scripts under one root namespace.
- Some scripts in project look experimental/prototype-only and may be excluded from production scene.

---

## 12) Risks & Gaps

- Health/game-over loop is not fully integrated in visible gameplay path.
- Shop purchases currently do not apply concrete gameplay effects.
- Balance values (spawn interval, move speed, score values) are prototype defaults.
- Needs final UI/UX pass for feedback (hit effects, death effects, game state transitions).

---

## 13) Milestones (Suggested)

### Milestone 1 - Core Combat Polish
- Finalize player death + restart flow.
- Add enemy and player hit VFX/SFX.
- Tune spawn cadence and movement speeds.

### Milestone 2 - Progression
- Define currency model.
- Connect shop items to real gameplay effects.
- Add upgrade persistence.

### Milestone 3 - Content Expansion
- Add 2-3 enemy archetypes.
- Add weapon variants and upgrade tree.
- Improve UI (HUD, game over, score summary).

### Milestone 4 - Release Candidate
- Bug fixing and balancing.
- Performance pass.
- Final presentation polish.

---

## 14) Success Metrics

- Average session length increases over builds.
- Repeat play rate (player restarts).
- Higher best-score trends.
- Shop engagement once progression is connected.

---

## 15) Change Log

- **v0.1 (Current):** Initial GDD generated from existing prototype structure and scripts.
