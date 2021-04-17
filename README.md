# Negum.Game

## 1. General Overview
Negum.Game is a library which provides core functionality and main game loop for 2D fighting game engine. <br/>
It is a higher lever wrapper around [Negum.Core](https://github.com/TheNegumProject/Negum.Core) library. <br/>
The main purpose of this library is to provide User with a set of pre-defined tools and classes which perform the most common and repetetive tasks. <br/>

### 1.1. Library structure
TBD

### 1.2. Features
- [X] General entities definition like [Player](https://github.com/TheNegumProject/Negum.Game/blob/main/Negum.Game/Common/Entities/IPlayer.cs), [Team](https://github.com/TheNegumProject/Negum.Game/blob/main/Negum.Game/Common/Entities/ITeam.cs), [Match](https://github.com/TheNegumProject/Negum.Game/blob/main/Negum.Game/Common/Entities/IMatch.cs)
- [ ] Standard fight (match) definition
- [X] Hook - Accept User input
- [ ] Hook - Render image / sprite
- [ ] Hook - Play audio / music
- [ ] Hook - Load font
- [ ] Hook - Draw menu
- [ ] Hook - Draw stage (background, foreground, effects)
- [ ] Hook - Draw player (sprite, effects)
- [ ] Add support for shaders
- [ ] Support triggers
- [ ] Singleplayer-only - F1 kills enemy
- [ ] Support configuration from [IEngine](https://github.com/TheNegumProject/Negum.Core/blob/main/Negum.Core/Engines/IEngine.cs)
- [ ] Main game loop
- [ ] Connect to local server for singleplayer
- [ ] Multiplayer support ([Client](https://github.com/TheNegumProject/Negum.Game/blob/main/Negum.Game/Client/INegumClient.cs), [Server](https://github.com/TheNegumProject/Negum.Game/blob/main/Negum.Game/Server/INegumServer.cs))
- [X] Client-Server communication via special [Packet](https://github.com/TheNegumProject/Negum.Game/blob/main/Negum.Game/Common/Packets/IPacket.cs)-system
- [ ] Up to 4 players offline (configurable)
- [ ] Max number of players online (configurable)

### 1.3. Sending single Packet pipeline
1. Client gathers data about the packet and serializes them
2. Client writes packet data to the communication stream
3. Server reads packet data
4. Server handles the packet
5. Server gathers data about the packet and serializes them
6. Server writes packet data to the communication stream
7. Client reads packet data
8. Client handles the packet

</br>

## 2. How To Use

### 2.1. Installation (NuGet)
Easiest wat to install Negum.Game library is to do it via NuGet like so:
> dotnet add package Negum.Game

Or check it directly [Here](https://www.nuget.org/packages/Negum.Game/)

### 2.2. Code / Sample Usage
TBD

</br>

## 3. Default Usage
TBD

</br>

## 4. License
[Click Me](https://github.com/TheNegumProject/Negum.Game/blob/main/LICENSE)
