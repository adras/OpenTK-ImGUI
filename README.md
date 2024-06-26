# OpenTK-ImGUI
Sample/Testing project for use of OpenTK with ImGUI

Alright, after spending hours fighting with the AI about which namespaces and which overloads to use in OpenTK
let alone integrating ImGUI luckily @NogginBops came to help with https://github.com/NogginBops/ImGui.NET_OpenTK_Sample

Since I'm going to need this probably more often, this project is supposed as a quickstart whenever you want to play around with OpenTK and ImGUI.

As of now this project uses .NET 8 with OpenTK 4.8.2

## General project requirements
This project was setup in a certain way:
* ```/unsafe``` Turned on in the project settings: allow unsafe code
* Nuget Packages, either put this block as a child of ```<Project>``` in your ```.csproj``` file or add them manually
  <ItemGroup>
    <PackageReference Include="ImGui.NET" Version="1.90.1.1" />
    <PackageReference Include="ImGuiNet.OpenTK" Version="0.1.6.123-beta" />
    <PackageReference Include="OpenTK" Version="5.0.0-pre.10" />
  </ItemGroup>

* Project output type is supposed to be Windows Application (unless you want an additional console window)

## Project structure

### OpenTK GameWindow
The main entry point, our App.Run class is OpenTk's GameWindow which is implemented in MyOpenTKApplication.cs.

From the perspective of the GameWindow only an Imgui.Draw call is required. Therefore the main drawing logic for Imgui is implemented in ImGuiRenderer.cs

### ImGuiRenderer
This class is heavily based on the Sample from @NogginBops.

The ImGuiRenderer is responsible for drawing ImGui using OpenGL.

Rendering works like this. ImGui is asked for the current data to render, the data is rendered with OpenGL.

### ImGuiController
This is basically supposed to be a single control. Right now it contains all demo's I found.
These are the two demo examples on ImGui's official github page along with the demo panel

### UserInput
For reasons beyond my knowledge, ImGUI only works when it's user input state is also updated. Therefore keyboard and mouse events need to passed to ImGui.

This is done by using the OpenTkImGuiInputConnector. When Connect is called OpenTk user events are registered. These events pass the given action to ImGui.
See [https://github.com/ocornut/imgui/blob/master/docs/FAQ.md#q-why-are-multiple-widgets-reacting-when-i-interact-with-a-single-one-q-how-can-i-have-multiple-widgets-with-the-same-label-or-with-an-empty-label](https://github.com/ocornut/imgui/blob/master/docs/FAQ.md#q-how-can-i-tell-whether-to-dispatch-mousekeyboard-to-dear-imgui-or-my-application)https://github.com/ocornut/imgui/blob/master/docs/FAQ.md#q-how-can-i-tell-whether-to-dispatch-mousekeyboard-to-dear-imgui-or-my-application
