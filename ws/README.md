# Xamarin Applications for Kaazing WebSocket API

This repository contains the Xamarin Sample Applications for Android, iOS Classic, and iOS Unified that use the Kaazing WebSocket API.

## Building instructions
__Note__: Sometimes Xamarin cannot properly restore the references from the packages configured via NuGet. As a result, the build solution fails.

To resolve this issue:
- Open KaazingWsXamarinDemo.Android
  - Open 'Packages'
  - Remove _all_ packages
  - Using NuGet add package "Xamarin.Forms"
- Open KaazingWsXamarinDemo.Common
  - Open 'Packages'
  - Remove _all_ packages
  - Using NuGet add package "Xamarin.Forms"
  - Using NuGet add package "Kaazing.Enterprize"
- Open KaazingWsXamarinDemo.iOS.Classic
  - Open 'Packages'
  - Remove _all_ packages
  - Using NuGet add package "Xamarin.Forms"
  
