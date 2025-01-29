# Stubo's Always Show Needs
![A screenshow showing the needs](needs.png)
A BepInEx plugin for Obenseuer that modifies the visibility behavior of status/needs indicators.

## Description
This mod changes how and when certain status effects and needs are displayed in the UI:
- Shows basic needs (Hunger, Thirst, Sleep, WC, Depression, Health, Hygiene) at all times
- Only shows addictive needs (Alcohol, Mushrooms, Smokes) when their value is above 1%
- Only shows special statuses (Ducks, Bleeding) when their values indicate an actual effect

## Features
- Configurable visibility thresholds for every stat in the game
- Ability to disable the mod's effects on specific stats
- Default threshold setting that applies to all stats

## Requirements
- Obenseuer
- [BepInEx 5](https://github.com/BepInEx/BepInEx)

## Installation
1. Install BepInEx 5 if you haven't already
2. Download the latest release
3. Extract the contents into your \SteamLibrary\steamapps\common\Obenseuer\ folder
4. Download this plugin via the ZIP file in releases the right of this page. Extract to \SteamLibrary\steamapps\common\Obenseuer\BepInEx\plugins
5. Run the game once to generate the configuration file
6. Edit the configuration file in \SteamLibrary\steamapps\common\Obenseuer\BepInEx\config if desired

## Configuration
The mod creates a configuration file with these settings:

### General Settings
- `DefaultThreshold`: Default visibility threshold for all stats (default: 1%)

### Individual Stat Settings
You can set custom thresholds for each stat:
- Health, Hygiene, Bleeding, Hunger, Thirst, Sleep, WC, Alcohol, Mushrooms, Smokes, Depression, Ducks
- Each stat can be individually disabled if you want it to use the game's default behavior

## Permissions
This mod is released under MIT license with the following conditions:
- Feel free to use and modify the code for personal use
- Ask permission before including in mod packs
- Do not upload to other sites without permission
- Credit must be given for any public use or modifications

## Credits
Created by StuboUK

## Contributing
Feel free to submit issues or suggest improvements through GitHub issues.
