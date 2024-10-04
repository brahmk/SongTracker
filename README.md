## SongTracker 

### Requirements:
- Visual Studio 2022 (or newer)
- .NET 8 SDK
- SQL Server (local instance or remote)

### Setup:

1. Clone the repository:
   ```
  git clone https://github.com/brahmk/songtracker.git
   ```

2. Modify `appsettings.json`:
   Update the connection string in `appsettings.json` to point to your SQL Server instance.

3. Run the database setup script and insert sample data:
   - Navigate to the `Data/Scripts` folder and run `create-and-seed.sql` in your SQL Server.


4. Open the solution in Visual Studio and build the project.

5. Run the project (F5).
