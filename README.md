<blockquote class="twitter-tweet"><p lang="en" dir="ltr">it&#39;s called CrapFixer. let that clean in🧽<a href="https://t.co/UP2iLnAgif">https://t.co/UP2iLnAgif</a><a href="https://twitter.com/hashtag/CrapFixer?src=hash&amp;ref_src=twsrc%5Etfw">#CrapFixer</a> <a href="https://twitter.com/hashtag/Windows?src=hash&amp;ref_src=twsrc%5Etfw">#Windows</a> <a href="https://twitter.com/hashtag/Windows11?src=hash&amp;ref_src=twsrc%5Etfw">#Windows11</a> <a href="https://twitter.com/hashtag/app?src=hash&amp;ref_src=twsrc%5Etfw">#app</a> <a href="https://twitter.com/hashtag/microsoft?src=hash&amp;ref_src=twsrc%5Etfw">#microsoft</a> <a href="https://t.co/OMruEjvuUb">pic.twitter.com/OMruEjvuUb</a></p>&mdash; Belim (@builtbybel) <a href="https://twitter.com/builtbybel/status/1917594071582773272?ref_src=twsrc%5Etfw">April 30, 2025</a></blockquote>

# Crap F🧼xer – Fixes the crap Windows leaves behind.

## The tool that says what everyone's thinking
## The tool Microsoft would build if they hated bloatware as much as we do

Remember the days when you'd run a registry cleaner even if you didn't really need it? (Or maybe we did need it? I was probably too young to figure that out - too young for that crap 😅)
Back then, cleaner tools like CCleaner were everywhere; it felt like every other tech forum had a "top 10 Windows Optimizers" list.

You'd think that stuff would be over by now with sleek, modern OSes like Windows 11. Well... the built-in Windows cleaner might be enough, sure.
But instead, the "modern OS" blesses us with a whole new batch of problems: ads in the Start menu, creepy data collection, and preinstalled junk apps you didn't ask for and can't easily remove.
It's kind of wild that we still need tools like this in 2025. And they don't even sound that different - like this one here: CrapFixer.
What can I say? The tech world is a bitch.

This is my personal little IT toolbox that I've been using for years to clean up and tweak Windows systems I work on. The tool is about 7 years old, but I've given the codebase a full refresh, especially tuned for Windows 11 (works on W10 too). I've also removed most of the old enterprise scripts, so what you're seeing now is a lightweight, easy-to-use, and safe app. Almost every change you make can be undone, so you can tweak without fear.

CrapFixer still looks like something straight out of the Windows XP era (maybe Crap Cleaner 😄) - and honestly, that's exactly the vibe I was going for. Sometimes simple just beats fancy. Two clicks: 'Analyze', check the results, 'Fix' - done. No drama, no bloat.

While cleaning up my GitHub (30+ repos down to 20 now), I also cleaned up thousands of lines of old code. Some projects come and go, but CrapFixer stays. It's fast, simple, and basically bulletproof. I haven't managed to break anything yet. 😉
If you like old-school tools that just work, you're gonna feel right at home.
If there's enough interest, I'll also commit the updated code to GitHub soon.

![explorer_xu59FtMUnG](https://github.com/user-attachments/assets/fe462326-ebfb-41ea-83b5-d4cf72659c2d)

<details>
  <summary>💬 A personal note from the developer</summary>

If you're curious about the personal story behind this project and others...
👉 [Read the full story here](https://github.com/Belim/support/blob/main/STORY.md)

</details>

## 🚀 How to Use CrapFixer

1.  **Launch the Tool**
    Many optimization options are enabled by default – no need to tweak anything unless desired.

2.  **Analyze Your System**
    Click **"Analyze"** to scan your system based on the selected settings in the tree view.

    -   **Red** items = Issues found or settings not matching recommendations.
    -   **Gray** items = Settings are already configured as recommended.

3.  **Apply Fixes**
    Click the **"Fix"** button (or the main action button, if the label changes) to apply the recommended tweaks for all checked items.

> ⚠️ **Tip:** To view what a tweak does, you can **Right-Click** on an item and select **Help** or hit **F1**.
> The help system also includes an online lookup that will search for more information about the tweak.

4.  **🔍 Optional: Review the Log**
    Still unsure about the results?
    → Upload your log to the [Online Log Analyzer](https://builtbybel.github.io/CrapFixer/log-analyzer/index.html)
    → Get a breakdown of the changes
    → Share the link for feedback if needed

> ⚠️ **Tip:** For full functionality, run CrapFixer as **Administrator**.
> Some fixes (like registry edits under `HKEY_LOCAL_MACHINE`) need elevated permissions.

## ☕ Motivation ≈ Caffeine

**CrapFixer** is my newest — and likely last — fine-tuning app for Windows.
I'm committed to keeping it alive for the long haul, and future development will be powered by **voluntary donations**.

---

> 💡 Every coffee-sized tip not only fuels new features —
> it also lowers the risk of *me* throwing a personal **Blue Screen of Death**. 😵‍💫

### 🙏 Support My Work

If you like CrapFixer, consider keeping it caffeinated:

[![Donate via PayPal](https://img.shields.io/badge/Donate-PayPal-0070BA?style=for-the-badge&logo=paypal&logoColor=white)](https://www.paypal.com/donate/?hosted_button_id=M9DW4VNKH9ECQ)
[![Support on Ko‑fi](https://img.shields.io/badge/Support-Ko–fi-F16061?style=for-the-badge&logo=ko-fi&logoColor=white)](https://ko-fi.com/builtbybel)

**Thank you for keeping the lights on!** ❤️

## Installation

*   Download the latest release from the [releases page](https://github.com/builtbybel/CrapFixer/releases).
*   Extract the archive.
*   Run `CFixer.exe`.

## Project Structure

The `CFixer` solution is organized as follows:

*   **`/CFixer/`**: The main directory for the CrapFixer application.
    *   **`Features/`**: Contains the core logic for individual tweaks and fixes. Each feature (e.g., disabling a specific ad, changing a setting) is typically implemented as a class derived from `FeatureBase.cs`.
        *   **`Ads/`**: Features related to disabling advertisements in Windows.
        *   **`AI/`**: Features related to AI components like Copilot.
        *   **`Edge/`**: Features specific to the Microsoft Edge browser.
        *   **`Gaming/`**: Tweaks for gaming performance or disabling gaming-related features.
        *   **`Issues/`**: General system issue fixes or cleanups.
        *   **`Privacy/`**: Features focused on enhancing user privacy.
        *   **`System/`**: Lower-level system tweaks and improvements.
        *   **`UI/`**: User interface customizations for Windows.
    *   **`Helpers/`**: Utility classes and helper functions used across the application (e.g., `Logger.cs`, `OSHelper.cs`, `Utils.cs`).
    *   **`Views/`**: User interface components, such as custom controls or forms used within the main application window (e.g., `OptionsView.cs`, `AboutView.cs`).
    *   **`Properties/`**: Project properties, resources (like images, icons), and settings.
    *   **`MainForm.cs`**: The main window of the application.
    *   **`Program.cs`**: The main entry point of the application.
*   **`/CFixer.Tests/`**: (Planned) Unit tests for the application.
*   **`/plugins/`**: Contains PowerShell (`.ps1`) scripts that can be run as plugins from within CrapFixer. Their metadata is defined in `plugins_manifest.txt`.
*   **`/docs/`**: Additional documentation, including the online log analyzer.

## Build Instructions

-   Visual Studio 2022+ with .NET Desktop workload.
-   (Optional but recommended) Windows 8.1 SDK or newer for full WinRT API access.
-   Clone the repository:
    ```bash
    git clone https://github.com/builtbybel/CrapFixer.git
    cd CrapFixer
    ```
-   Open `CFixer.sln` in Visual Studio or build from the command line:
    *   **Using .NET SDK CLI (Recommended for modern environments):**
        ```bash
        dotnet build CFixer.sln -p:Configuration=Release
        ```
        If building on a non-Windows system or if .NET Framework targeting packs are not automatically found by the .NET SDK, you might need Mono installed and to specify the path to .NET Framework reference assemblies:
        ```bash
        dotnet build CFixer.sln -p:Configuration=Release -p:FrameworkPathOverride=/usr/lib/mono/4.8-api/
        ```
        (Adjust the `FrameworkPathOverride` path based on your Mono installation.)
    *   **Using MSBuild (Traditional):**
        ```bash
        msbuild CFixer.sln /p:Configuration=Release
        ```

> ⚠️ **Important for Building `CFixer.csproj`:**
> This project uses some Windows Runtime (WinRT) APIs (e.g., `Windows.Management.Deployment`). For classic .NET Framework projects (like `CFixer.csproj`), Visual Studio or MSBuild might not resolve these automatically.
> If you encounter build errors related to WinRT types:
> 1. Ensure you have a Windows SDK installed (e.g., Windows 10 or 8.1 SDK).
> 2. You may need to manually add a reference in `CFixer.csproj` to `Windows.winmd`. A typical path is:
> `C:\Program Files (x86)\Windows Kits\10\UnionMetadata\{SDK_VERSION}\Windows.winmd`
> or for older SDKs:
> `C:\Program Files (x86)\Windows Kits\8.1\References\CommonConfiguration\Neutral\Annotated\Windows.winmd`
> The project currently includes a hint path for the 8.1 SDK version. Adjust if necessary for your system.

### Build with Visual Studio (GUI)

-   Open `CFixer.sln`.
-   Set the build configuration to **Release | AnyCPU**.
-   Build the solution (e.g., `Ctrl + Shift + B` or Build > Build Solution).

After building, the executable can be found in `CFixer/bin/Release/` (or `CFixer/bin/Debug/`).

## Contributing

We welcome contributions to CrapFixer! Here are some guidelines to help you get started:

### How to Add a New Feature

1.  **Create a Feature Class:**
    *   New features should be implemented as classes within the `CFixer/Features/` directory, usually under an appropriate sub-category (e.g., `Ads`, `Privacy`, `UI`).
    *   Your class must inherit from `FeatureBase` (located in `CFixer/Features/FeatureBase.cs`).
    *   Implement all abstract methods from `FeatureBase`:
        *   `ID()`: A unique string identifying your feature (e.g., "Disable Super Tracking").
        *   `Info()`: A short, user-friendly description of what the feature does.
        *   `GetFeatureDetails()`: A more detailed explanation, often including the registry keys or settings it affects. This is shown in previews and logs.
        *   `CheckFeature()`: Asynchronously checks the current state of the setting. Return `true` if the system is configured as your feature *recommends* (e.g., if a privacy-invasive feature is already off), `false` otherwise (e.g., if the ad is still enabled).
        *   `DoFeature()`: Asynchronously applies the fix or tweak. Return `true` if successful, `false` on error.
        *   `UndoFeature()`: Reverts the changes made by `DoFeature()`. Return `true` if successful, `false` on error.
    *   Use the `Logger` class for any output.

2.  **Feature Loading:**
    *   The `FeatureLoader` class automatically discovers and loads all classes inheriting from `FeatureBase` in the `CrapFixer` assembly. You typically don't need to manually register your new feature class, just ensure it's part of the project.

### How to Add a New Plugin

1.  **Create a PowerShell Script:**
    *   Write your plugin as a PowerShell script (`.ps1`) and place it in the `/plugins/` directory.
    *   The script can perform any actions you need. Use standard PowerShell cmdlets.

2.  **Update Plugin Manifest:**
    *   Add a new line to `/plugins/plugins_manifest.txt`.
    *   The format for each line is: `Plugin Name;Description;FilePath.ps1`
        *   Example: `My New Plugin;This plugin does something cool;MyNewPlugin.ps1`

### Coding Style

*   Please try to follow the existing coding style found in the project.
*   Use XML documentation comments for all public classes, methods, and properties you create or modify (see existing code for examples). This helps keep the codebase maintainable and understandable.
*   Keep methods concise and focused on a single responsibility where possible.

### Testing

*   While formal unit tests are still being established for all parts of the application, **manual testing is crucial.**
*   Thoroughly test your new feature or plugin on the target Windows version(s).
*   Test both the "do" and "undo" functionality of your feature.
*   When submitting a bug report, please provide clear, step-by-step instructions to reproduce the issue. Include information about your Windows version and any relevant logs from CrapFixer.
*   If possible, test on different Windows versions (e.g., Windows 10 and Windows 11) and note any differences in behavior.

Your contributions are appreciated in making CrapFixer a more effective tool for everyone!

## System Requirements

-   Windows 11 (Recommended)
-   Windows 10
-   Administrator privileges required for full functionality.

## License

This project is licensed under the MIT License - see the [LICENSE](./LICENSE) file for details.
