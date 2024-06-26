# Tour Planner
by Nahi Islam Jashim & Bayram-Enes Yenipinar | for our fourth semester project

GitHub-Repository: https://github.com/njashim/tourPlanner



#### app architecture (class diagrams are missing)

Our Tour Planner application is designed to manage various tours and their associated logs. It uses a multi-layered architecture consisting of the following layers: UI Layer, Business Layer (BL), Data Access Layer (DAL), and Model Layer.

**UI Layer**

The UI Layer is responsible for the application's user interface, which is implemented with Blazor. This layer follows the MVVM (Model-View-ViewModel) pattern to separate the UI logic from the business logic, providing a clean and maintainable structure. The UI Layer includes the following functionalities:

- Displaying and managing a list of tours.
- Creating, modifying, and deleting tours.
- Creating, modifying, and deleting tour logs.
- Viewing detailed information about each tour and its associated logs.
- Generating reports (tour reports and summary reports).
- Performing full-text searches on tour and tour-log data.

**Business Layer**

The Business Layer contains the core logic of the application. It acts as an intermediary between the UI Layer and the Data Access Layer. This layer processes data, applies business rules, and ensures that the data is correctly managed before being sent to the UI or DAL. Key responsibilities of the BL include:

- Handling CRUD operations for tours and tour logs.
- Computing derived attributes such as tour popularity and child-friendliness.
- Interfacing with external services to retrieve tour-related data (e.g., distance and time using OpenRouteservice API).
- Managing the business rules and validations for user inputs.

**Data Access Layer**

The Data Access Layer is responsible for interacting with the PostgreSQL database and managing data persistence. This layer uses Entity Framework Core as an Object-Relational Mapper (ORM) to map objects in the application to database records, facilitating easy data manipulation. The DAL performs the following functions:

- Storing and retrieving tour and tour-log data.
- Managing database connections and transactions.
- Storing images related to tours externally in the filesystem.
- Ensuring that data operations are performed efficiently and reliably.

**Model Layer**

The Model Layer defines the data structures used throughout the application. It includes classes representing the entities (e.g., Tour, TourLog) and their properties. The model is used by both the BL and DAL to ensure consistency in the data being processed and stored. This layer ensures that data integrity is maintained and that the application can evolve without breaking existing functionality.

#### UX (Wireframe)

<img src="img\TourWireframe.png" alt="TourWireframe" style="zoom:80%;" />

<img src="img\TourlogWireframe.png" alt="TourLogWireframe" style="zoom:80%;" />

**Description:**

These wireframes depict a user interface for a "Tour Log" web application, emphasizing simplicity and ease of navigation. The goal is to allow users to view and manage their tour logs efficiently.

In the first wireframe, the header contains standard web browser elements: back, forward, and home buttons, a URL bar displaying "https://localhost," and a search icon on the far right. Below the header, a vertical sidebar on the left is labeled "Tour Log" with a location icon, likely serving as the main navigation for different sections of the tour log application.

The main content area is divided into two sections. At the top, there are six rectangular buttons arranged in a grid layout, presumably used to navigate to different logs or perform various actions related to the tour logs. Below these buttons, two primary action buttons are side-by-side, likely for adding a new log or editing an existing one. Beneath the action buttons, a search bar allows users to quickly find specific logs or entries. Under the search bar is a list view area displaying tour logs or search results. On the right side of the main content area, there is a section titled "Tour Log Details," featuring a map and some text information related to a selected tour log.

In the second wireframe, the header remains consistent with the first, maintaining the same web browser elements for uniformity and ease of navigation. The sidebar on the left is similar but is labeled "Tour" instead of "Tour Log," indicating a different section of the application. The main content area again has a top section with rectangular buttons, but this time there are only four, suggesting fewer options or a more focused set of actions for this section. Below these buttons, two primary action buttons are placed similarly to the first wireframe for adding or modifying tour details. The search bar is positioned below the buttons for searching within the tour details. The list view area displays search results or tour entries. On the right, a "Tour Details" section features a map and related text information, analogous to the "Tour Log Details" section in the first wireframe.

The user experience (UX) focuses on consistency, as both wireframes share a similar layout to help users navigate the application without confusion. The header and sidebar elements are stable, providing a familiar context. Navigation is facilitated through the use of buttons and search functionality, allowing easy access to different logs and tour details. Information display is handled by the right-side details sections with maps and text, ensuring that users can view relevant details without leaving the main page. Primary action buttons are prominently placed, making it straightforward for users to add or edit entries.
