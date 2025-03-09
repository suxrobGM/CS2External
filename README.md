# CS2External

## Description

CS2External it is a fork of [FullyExternalCS2](https://github.com/sweeperxz/FullyExternalCS2) with some improvements and new features.
It is a an external cheat for Counter-Strike 2 that reads memory and interacts with the game process externally without injecting any code into the game process or modifying the game in any way.

> [!IMPORTANT]
> Note: This project is for educational and research purposes only. I am not responsible for any harm caused by this software.

![SS](docs/photo.png)

## Features

### AimBot

- Key activation with RCS (default = LBUTTON)
- Visibility check

### Esp

- Skeleton (Color team)
- Box with health bar
- Health numbers
- Name
- Enemy weapon
- Enemy flags (Scoped, Flashed, Shifting, Shifting in scope)

### Other Visuals

- Aim Crosshair
- [Bomb timer](https://streamable.com/ylouzc)

### Trigger Bot

- Key activation (default = LAlt)
- [No Spread](https://streamable.com/9ltv4n)

### Miscellaneous

- [BunnyHop](https://streamable.com/3r09m1) ([Read this](src/CS2External/Core/Entities/Player.cs#L64))
- OBS Bypass - Stream safely without detection

### System

- Auto update offsets
- Offsets will be downloaded from the [GitHub](https://github.com/a2x/cs2-dumper) repository

### Configuration

- Certain functionalites such as Aimbot, and Triggerbot can be toggled on and off in the [appsettings.json](./src/CS2External/appsettings.json) file.

## Installation & Usage

### Prerequisites

- Download and install [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet)

### Step 1: Clone the Repository

```bash
git clone https://github.com/suxrobGM/CS2External.git
cd CS2External
```

### Step 2: Build & Run

```bash
dotnet build
dotnet run
```

### Alternative: Precompiled Binaries

You can also download the precompiled binaries from the [Releases](https://github.com/suxrobgm/CS2External/releases) page without downloading .NET SDK and building the project.

### Help

If you have issues or have questions, check out the Issues section of the GitHub project page.

### Authors

- [sweeperxz](https://github.com/sweeperxz) - Developer/Engineer (original author of [FullyExternalCS2](https://github.com/sweeperxz/FullyExternalCS2))
- [suxrobGM](https://github.com/suxrobGM) - Developer/Engineer (fork author)
