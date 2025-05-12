# Crapf🧼xer

# The tool that says what everyone's thinking

## The tool Microsoft would build if they hated bloatware as much as we do

Remember the days when you'd run a registry cleaner even if you didn't really need it? (Or maybe we did need it? I was probably too young to figure that out - too young for that crap 😅)
Back then, cleaner tools like CCleaner were everywhere; it felt like every other tech forum had a "top 10 Windows Optimizers" list.

You'd think that stuff would be over by now with sleek, modern OSes like Windows 11. Well... the built-in Windows cleaner might be enough, sure.
But instead, the "modern OS" blesses us with a whole new batch of problems: ads in the Start menu, creepy data collection, and preinstalled junk apps you didn't ask for and can't easily remove.
It's kind of wild that we still need tools like this in 2025. And they don't even sound that different - like this one here: Crapfixer.
What can I say? The tech world is a bitch.

This is my personal little IT toolbox that I've been using for years to clean up and tweak Windows systems I work on. The tool is about 7 years old, but I've given the codebase a full refresh, especially tuned for Windows 11 (works on W10 too). I've also removed most of the old enterprise scripts, so what you're seeing now is a lightweight, easy-to-use, and safe app. Almost every change you make can be undone, so you can tweak without fear.

Crapfixer still looks like something straight out of the Windows XP era (maybe CCleaner 😄) - and honestly, that's exactly the vibe I was going for. Sometimes simple just beats fancy. Two clicks: 'Analyze', check the results, 'Fix' - done. No drama, no bloat.

While cleaning up my GitHub (30+ repos down to 20 now), I also cleaned up thousands of lines of old code. Some projects come and go, but Crapfixer stays. It's fast, simple, and basically bulletproof. I haven't managed to break anything yet. 😉
If you like old-school tools that just work, you're gonna feel right at home.
If there's enough interest, I'll also commit the updated code to GitHub soon.

![Fixing the crap](https://github.com/user-attachments/assets/cb568d53-113e-4a14-8c88-30e822b45bd3)

## Features

- **Debloat Windows:** Say goodbye to unwanted pre-installed apps.
- **Enhance Privacy:** Take control of data collection settings.
- **Streamline Performance:** Tweak your system for a smoother experience.
- **User-Friendly & Safe:** Classic UI with reversible changes for peace of mind.

## How to Use Crapfixer

Using Crapfixer is straightforward:

1. **Launch the Tool:** All optimization options are enabled by default to save you time.
2. **Analyze Your System:** Simply click the "Analyze" button. Crapfixer will check your system against the selected options.
   - Items marked in **red** are recommended fixes.
   - Items in **gray** are already configured correctly.
3. **Apply Fixes:** Then just smash the "Run CFixer!" button and you're good to go.

_For full functionality, it's recommended to run the app as Administrator, since certain features - like editing registry values under HKEY_LOCAL_MACHINE - require elevated permissions._

## System Requirements

- Windows 11 (Recommended)
- Windows 10
- Administrator privileges required for full functionality.

## License

This project is licensed under the MIT License - see the [LICENSE](./LICENSE) file for details.
