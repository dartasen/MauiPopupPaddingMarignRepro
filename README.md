# MAUI Community Toolkit Popup Padding/Margin Issue

Context: [https://github.com/CommunityToolkit/Maui/issues/3064#issuecomment-3865240610](https://github.com/CommunityToolkit/Maui/issues/3064#issuecomment-3865240610)

# Issue
Migration from 13 to 14 cause Popup settings to misbehave :

Tested on Windows, Android and iOS

Before (13.0.0) :
<img width="1423" height="824" alt="image" src="https://github.com/user-attachments/assets/ba5cb45d-33e9-4368-8e91-ab16b28ea142" />


After (14.0.0) :
<img width="1409" height="807" alt="image" src="https://github.com/user-attachments/assets/d6d2e766-1045-4a77-8857-9a523d29d27b" />

## Steps

* Launch application on Windows for example
* Click on button, popup should be like After* screenshot
* In `PopupRepro.csproj`, Change `<PackageReference Include="CommunityToolkit.Maui" Version="14.0.0" />` to `<PackageReference Include="CommunityToolkit.Maui" Version="13.0.0" />`
* Relaunch application
* Click on button, popup should be like Before* screenshot
