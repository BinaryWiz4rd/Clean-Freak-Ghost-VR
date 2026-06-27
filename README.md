# Clean Freak Ghost - VR Escape Room

A Virtual Reality escape room game built in **Unity 6** using the **XR Interaction Toolkit**. 

## 👻 Game Concept
You are suddenly trapped in a mysterious, messy room by a **Clean Freak Ghost**. The ghost refuses to let you leave until the entire place is spotless! You are given a specific checklist of chores to complete. Once the room meets the ghost's high standards, the locked doors will magically disappear, allowing you to escape. However, if you take too long, the ghost will lose its patience...

## 🛠️ Current Implementation
- **VR Simulator Setup:** Fully integrated XR Device Simulator for fast, headset-free development testing.
- **Physical Trash Interaction:** Implemented `XR Grab Interactable` components on 5 old trash cans spread across the scene.
- **Physics & Colliders Configuration:** Properly configured non-static rigidbodies and mesh colliders allowing players to pick up, carry, and drop objects dynamically.
- **Introductory UI Storyline:** Integrated the start menu and narrative canvas into a separate `MainMenu` scene, which smoothly loads the main gameplay.
- **Atmospheric UI Graphics:** Customized the canvases using horror-themed fonts (Special Elite) and grunge/blood textures for an immersive look.
- **Dynamic Dashboard & Timer:** Implemented a functional countdown timer with a neon glow effect and a live-updating to-do checklist ("Cans Remaining: X/5").
- **Win/Lose Conditions:** Added logic that triggers victory when all trash is inside `Sink_V1` and defeat when the timer hits zero.

## 🚀 Future Roadmap
- **Audio & Sound Effects:** Creepy background music and sound effects for gathering trash or the ticking clock.
- **Visual Feedback:** Dimming or flickering lights as the timer gets closer to zero to increase pressure.
- **More Chores:** Introducing different types of mess scattered around the room to expand the game.
