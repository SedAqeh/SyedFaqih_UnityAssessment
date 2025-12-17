# UnityAssessment

This repository contains a Unity project developed as a technical assessment.  
It demonstrates scene management, input handling, GPU-based particle simulation, and performance-oriented design using modern Unity tools.

---

## Unity Version

- **Unity 2022 LTS or later**  
  (Developed and tested on a later LTS version)

---

## Project Overview

The project consists of **two scenes**:

- **Scene 1** – Object interaction, UI feedback, and scene transition
- **Scene 2** – High-performance particle simulation (1,000,000+ particles)

---

## Scene 1 – Cube Interaction & Scene Transition

### Features

- Two cubes:
  - **Red cube** → controlled with `W A S D`
  - **Green cube** → controlled with arrow keys
- Movement restricted to the **XZ plane**
- Fixed **top-down camera** that keeps all objects in view
- **20 spheres**, each with a different texture
  - Hidden by default
- Particle streams emitted from each cube toward the other
- On-screen UI showing the **current distance between cubes**

### Logic

- Distance **> 2 units** → spheres hidden
- Distance **< 2 units** → spheres visible
- Distance **< 1 unit** → automatic transition to **Scene 2**

---

## Scene 2 – Million Particle Simulation

### Features

- **More than 1,000,000 particles** rendered simultaneously
- Implemented using **Visual Effect Graph** for GPU-based simulation
- Particles move randomly while remaining constrained within a spherical volume
- No per-particle CPU logic

---

## Bonus Task – Spinner Interaction

### Spinner

- Placed at the center of the scene
- Camera remains fixed above, looking down

### Interaction

- Click and drag on the spinner to spin it
- Spinner rotation is driven by analytic angular impulse
- While spinning:
  - Particles within the influence radius are pushed outward
- When not spinning:
  - Particles pass through unaffected

### Notes

- No physics-based particle collision
- Interaction handled entirely on the GPU
- Designed to scale efficiently with large particle counts

---

## Bonus Task with Extra Credit – Dynamic Particle Texture

### Functionality

- Scene 2 includes a **text input field**
- User can input a URL to an image

### Validation

- Only `.jpg` and `.png` URLs are accepted
- Invalid formats are rejected

### Behavior

- Valid images are downloaded asynchronously using **async/await**
- The downloaded image is applied directly to the particle system
- The image replaces the main texture used by particles at runtime

### Technical Details

- Uses `UnityWebRequestTexture`
- Fully non-blocking (no Coroutines)
- Texture is applied once and reused on the GPU

---

## Performance & Optimization

- GPU-based particle simulation using **Visual Effect Graph**
- Async/await-based networking
- No per-frame CPU particle updates
- Minimal runtime allocations
- Radial force-based constraints instead of physics collisions

---

## How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/SedAqeh/SyedFaqih_UnityAssessment.git
   ```
2. Open the project in **Unity 2022 LTS or later**
3. Open **Scene 1**
4. Press ▶ Play

---

## Test Image URLs (for Bonus Task)

**JPG**

```
https://upload.wikimedia.org/wikipedia/commons/3/3f/JPEG_example_flower.jpg
```

**PNG (with transparency)**

```
https://upload.wikimedia.org/wikipedia/commons/4/47/PNG_transparency_demonstration_1.png
```

---

## Notes

- The project prioritizes performance, clarity, and scalability
- Analytic and GPU-driven approaches are favored over heavy physics systems
- Code is structured for readability and easy extension
