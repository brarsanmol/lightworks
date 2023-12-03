# lightworks 🚦

> a fun lighting mod for [lethal company](https://store.steampowered.com/app/1966720/Lethal_Company/)!

# installation
1. **download the latest release which can be found [here](https://github.com/brarsanmol/lightworks/releases).**
2. **paste into the bepinex plugins folder**
   - navigate to `C:\Program Files (x86)\Steam\steamapps\common\Lethal Company\BepInEx\plugins\`.
   - paste the `LightWorks.dll` file here.

# contributing

### dependencies

#### general
* [.NET SDK 7.0.404](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

#### nuget
* [BepInEx](https://docs.bepinex.dev/articles/dev_guide/plugin_tutorial/1_setup.html#installing-bepinex-plugin-templates)
* [HarmonyLib](https://www.nuget.org/packages/Lib.Harmony)

#### dlls

1. **go to installation directory**
   - find your "Lethal Company" installation folder, it is most commonly located at `C:\Program Files (x86)\Steam\steamapps\common\Lethal Company\Lethal Company_Data\Managed`.
2. **find the files**
   - find the following dlls in the folder and select them for copy.
     - Assembly-CSharp.dll
     - Unity.InputSystem.dll
     - Unity.Netcode.Runtime.dll
     - UnityEngine.dll
     - UnityEngine.CoreModule.dll
3. **paste the files**
   - paste the files selected previously into the `Libraries` folder, this is **essential** otherwise you will be unable to build the mod, or use intellisense.

### installation
1. **build**
   - run `dotnet build` in your project's root directory.
2. **install**
   - find the `LightWorks.dll` in `bin\Debug\netstandard-2.1`.
   - copy this file.
3. **paste into bepinex plugins folder**
   - navigate to `C:\Program Files (x86)\Steam\steamapps\common\Lethal Company\BepInEx\plugins\`.
   - paste the `LightWorks.dll` file here.

# authors
* [Anmol Brar](mailto:hey@anmolbrar.ca?subject=[LightWorks])

# license
this project is licensed underneath the [mit license](https://github.com/brarsanmol/lightworks/LICENSE).