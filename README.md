# Knight's Trial

<table>
  <tr>
    <td align="left" width="100%">
      <img width="100%" alt="gif1" src="https://media.giphy.com/media/C08nPkJMWxpUal1Aq6/giphy.gif">
    </td>
    <!-- <td align="right" width="50%">
      <img width="100%" alt="gif2" src="https://github.com/user-attachments/assets/f96b78ce-3f23-4b2e-a17f-c7c1581d5cf5">
    </td> -->
  </tr>
</table>

Knight's Trial is a 2D side-scrolling action game where you play as a valiant knight battling endless waves of enemies. The game doesn’t end until you fall — every fight is a test of endurance. Defeat as many foes as you can, rack up your score, and push yourself to survive longer with each run.

---

## Developer
Ngakan Nyoman Arya Vedantha (Game Programmer)
<br>

## Built Time
The game was built for 14 days.
<br>

## Features & Scripts 

<table>
  <tr>
    <th>Main Scripts</th>
    <th>Description</th>
  </tr>
  <tr>
    <td><code>Attack.cs</code>, <code>PlayerControl.cs</code>, <code>Damageable.cs</code></td>
    <td>Handling attack, movement (walk, jump) for the player, damaging.</td>
  </tr>
  <tr>
    <td><code>HealthText.cs</code>, <code>HealthPickUp.cs</code>, <code>ParallaxEffect.cs</code></td>
    <td>Handling user interface for game such as parallax, health text, item drop UI, </td>
  </tr>
  <tr>
    <td><code>LootItem.cs</code></td>
    <td>Manage healing item when player destroy an enemy.</td>
  </tr>
  <tr>
    <td><code>MusicPlayer.cs</code></td>
    <td>Manage the music for the game.</td>
  </tr>
  <tr>
    <td><code>Knight.cs</code>, <code>EnemySpawner.cs</code></td>
    <td>Manage enemy behaviour and spawning enemy.</td>
  </tr>
  <tr>
    <td><code>GameManager.cs</code>, <code>UIManager.cs</code></td>
    <td>Manage the player score when destroying enemy, displaying damage for both player and enemy.</td>
  </tr>
</table>

---

## Files description

```
├── KnightTrial                       # Contain everything needed for KnightTrial to works.
   ├── Assets                         # Contains every assets that have been worked with unity to create the game like the scripts and the art.
      ├── Sprites                     # Contains all the game art like the sprites, background, even the character.
      ├── Prefabs                     # Contains every reusable object that have been used in the game.
      ├── Sounds                      # Contains every sound used for the game like music and sound effects.
      ├── Scripts                     # Contains all scripts needed to make the gane get goings like PlayerMovement scripts.
      ├── UI                          # Contains every UI that is used in the game such as fonts and texts.
          ├── Fonts                   # Contains all the fonts that have been used in the game.
          ├── Text                    # Contains all the prefab text that have been used in the game such as damage text, health text.
  
```
<br>

## Game controls

The following controls are bound in-game, for gameplay and testing.

| Key Binding       | Function          |
| ----------------- | ----------------- |
| A,D           | Player movement |
| Jump           | Spacebar |
| Left Mouse Button        | Attack |

<br>

## Project Goal

This game was created as a **learning project** to experiment with Unity.

---
