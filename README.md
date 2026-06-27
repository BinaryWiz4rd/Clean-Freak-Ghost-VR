# Clean Freak Ghost - VR Escape Room

A Virtual Reality escape room game built in **Unity 6** using the **XR Interaction Toolkit**. 

## 👻 Game Concept
You are suddenly trapped in a mysterious, messy room by a **Clean Freak Ghost**. The ghost refuses to let you leave until the entire place is spotless! You are given a specific checklist of chores to complete. Once the room meets the ghost's high standards, the locked doors will magically disappear, allowing you to escape. However, if you take too long, the ghost will lose its patience...

## 🛠️ Current Implementation
- **VR Simulator Setup:** Fully integrated XR Device Simulator for fast, headset-free development testing.
- **Physical Trash Interaction:** Implemented `XR Grab Interactable` components on 5 old trash cans spread across the scene.
- **Physics & Colliders Configuration:** Properly configured non-static rigidbodies and mesh colliders allowing players to pick up, carry, and drop objects dynamically.

## 🚀 Future Roadmap
- **Introductory UI Storyline:** A narrative UI element at the start of the game explaining the ghost's backstory and your predicament.
- **Dynamic To-Do List Dashboard:** An interactive screen tracking your progress (e.g., "Cans Remaining: X/5").
- **On-Screen Gameplay Timer:** A ticking clock to increase tension.
- **Win/Lose Conditions:** - **Victory:** "You Escaped!" overlay triggering once all trash is placed inside the kitchen sink (`Sink_V1`).
  - **Defeat:** An angry ghost jump-scare/feedback loop if the player fails to clean up before the timer expires.