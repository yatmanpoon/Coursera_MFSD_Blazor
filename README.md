# Microsoft Copilot Blazor Development Demo

A simple web project that demonstrates how to use Microsoft Copilot to perform the front-end development in Blazor.

## Overview

This project demonstrates how to:
- initialize and create essential elements of a Blazor project
- build up Blazor components with two-way data binding
- set up routing between pages
- optimize performance and perform testing by Copilot

## Tech Stack

- C#
- .NET 10
- Blazor WebAssembly
- Bootstrap

## Project Structure

- `EaseEventApp/Pages/` - event list, event form, attendance tracker, and not-found pages
- `EaseEventApp/Models/` - event and attendance data models
- `EaseEventApp/Services/` - event and attendance services and their interfaces
- `EaseEventApp/Layout/` - shared layout and navigation
- `EaseEventApp/wwwroot/` - static assets and styles
- `DEPLOYMENT_GUIDE.md` - build and deployment guidance
- `PRODUCTION_READINESS.md` - production-readiness notes and recommendations

## How to Run

1. Install the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).
2. Clone the repository.
3. From the repository root, run:

   ```bash
   dotnet run --project EaseEventApp/EaseEventApp.csproj
   ```

4. Open the local URL printed in the terminal.

## Course

This is the final assignment for the Coursera course: Microsoft Full-Stack Developer Professional Certificate - Blazor for Front-End Development

## License

This project is for educational purposes.