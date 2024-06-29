# Tour Planner
by Nahi Islam Jashim & Bayram-Enes Yenipinar | for our fourth semester project

GitHub-Repository: https://github.com/njashim/tourPlanner

tracked time:  62 hours

#### app architecture

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



#### use cases

##### Use Case 1: Create Tour

**Actors:** User

**Description:** The user creates a new tour by providing necessary details.

**Basic Flow:**

1. The user selects the option to create a new tour.
2. The system prompts the user to enter tour details (name, description, start point, end point, transport type, distance, estimated time, and route image).
3. The user submits the details.
4. The system saves the tour information in the database and retrieves additional data using OpenRouteService APIs.
5. The system confirms the tour creation to the user.

##### Use Case 2: Manage Tours

**Actors:** User

**Description:** The user can view, edit, or delete existing tours.

**Basic Flow:**

1. The user selects the option to view tours.
2. The system displays a list of existing tours.
3. The user chooses to edit or delete a tour.
4. If editing, the user modifies the necessary details and submits them.
5. The system updates the tour information in the database.
6. If deleting, the user confirms the deletion.
7. The system removes the tour from the database.

##### Use Case 3: Log Tour

**Actors:** User

**Description:** The user logs a completed tour.

**Basic Flow:**

1. The user selects an existing tour to log.
2. The system prompts the user to enter log details (date/time, comment, difficulty, total distance, total time, rating).
3. The user submits the log.
4. The system saves the log information in the database.
5. The system updates the tour's computed attributes based on the new log.

##### Use Case 4: Full-Text Search

**Actors:** User

**Description:** The user performs a full-text search on tours and logs.

**Basic Flow:**

1. The user enters a search query.
2. The system processes the query and searches through the tours and logs data.
3. The system displays the search results to the user.

##### Full-Text Search Sequence

This sequence just describes the steps taken when a user performs a full-text search on the tour and log data.

**Basic Flow:**

1. **User**: Initiates the search by entering a query.
2. **UI Layer**: Sends the query to the Business Layer.
3. **Business Layer**: Processes the query, interacts with the Data Access Layer to fetch the relevant data.
4. **Data Access Layer**: Executes the search on the database and retrieves matching records.
5. **Business Layer**: Computes any additional required data (e.g., derived attributes).
6. **UI Layer**: Displays the search results to the user.



#### UX (Wireframe)

<img src="img\TourWireframe.png" alt="TourWireframe" style="zoom:80%;" />

<img src="img\TourlogWireframe.png" alt="TourLogWireframe" style="zoom:80%;" />

**Description:**

These wireframes depict a user interface for a "Tour Log" web application, emphasizing simplicity and ease of navigation. The goal is to allow users to view and manage their tour logs efficiently.

In the first wireframe, the header contains standard web browser elements: back, forward, and home buttons, a URL bar displaying "https://localhost," and a search icon on the far right. Below the header, a vertical sidebar on the left is labeled "Tour Log" with a location icon, likely serving as the main navigation for different sections of the tour log application.

The main content area is divided into two sections. At the top, there are six rectangular buttons arranged in a grid layout, presumably used to navigate to different logs or perform various actions related to the tour logs. Below these buttons, two primary action buttons are side-by-side, likely for adding a new log or editing an existing one. Beneath the action buttons, a search bar allows users to quickly find specific logs or entries. Under the search bar is a list view area displaying tour logs or search results. On the right side of the main content area, there is a section titled "Tour Log Details," featuring a map and some text information related to a selected tour log.

In the second wireframe, the header remains consistent with the first, maintaining the same web browser elements for uniformity and ease of navigation. The sidebar on the left is similar but is labeled "Tour" instead of "Tour Log," indicating a different section of the application. The main content area again has a top section with rectangular buttons, but this time there are only four, suggesting fewer options or a more focused set of actions for this section. Below these buttons, two primary action buttons are placed similarly to the first wireframe for adding or modifying tour details. The search bar is positioned below the buttons for searching within the tour details. The list view area displays search results or tour entries. On the right, a "Tour Details" section features a map and related text information, analogous to the "Tour Log Details" section in the first wireframe.

The user experience (UX) focuses on consistency, as both wireframes share a similar layout to help users navigate the application without confusion. The header and sidebar elements are stable, providing a familiar context. Navigation is facilitated through the use of buttons and search functionality, allowing easy access to different logs and tour details. Information display is handled by the right-side details sections with maps and text, ensuring that users can view relevant details without leaving the main page. Primary action buttons are prominently placed, making it straightforward for users to add or edit entries.



####  library decisions

* **ORM Library:** Entity Framework (EF) Core because Nahi has already gained experience with this framework at work.
* **Logging Library:** log4net because it has already been suggested by the specification
* **Report Generation Library:** iText7 because it was introduced in the self-study

#### lessons learned

- **Effective Use of Libraries**: Choosing the right libraries like Entity Framework Core, log4net, and iText7 streamlined development and enhanced functionality.
- **Importance of Clear Separation**: Implementing a layered architecture improved code maintainability and clarity.
- **Performance Considerations**: Optimizing ORM usage and managing logging granularity were essential for maintaining performance.
- **Handling External Services**: Integrating with external APIs required robust error handling and planning for rate limits.
- **Report Generation**: Using a powerful library like iText7 made complex report creation manageable once its features were understood.



#### implemented design pattern

**Repository Pattern**

The Repository Pattern is used to abstract and encapsulate data access logic, providing a clean separation between the business logic and data access layers. It centralizes data operations, making it easier to manage and maintain.

**Implementation in Tour Planner:**

- **TourRepository and TourLogRepository**: These classes handle CRUD operations for tours and tour logs.
- **Interface Definition**: `ITourRepository` and `ITourLogRepository` define the contract for these repositories, ensuring consistency and flexibility.
- **Entity Framework Core**: Used within the repository classes to interact with the PostgreSQL database, providing efficient and simplified data access.

**Service Pattern**

The Service Pattern encapsulates business logic into service classes, promoting reusability and separation of concerns. Services provide a centralized way to manage business operations and can be used across different parts of the application.

**Implementation in Tour Planner:**

- **TourService**: Manages tour-related operations such as creation, modification, deletion, and retrieval of tours.
- **TourLogService**: Handles operations related to tour logs.

**Model-View-ViewModel (MVVM) Pattern**

The MVVM Pattern separates the user interface (View) from the business logic (ViewModel) and data (Model). It is particularly suitable for Blazor applications, promoting a clean and maintainable codebase.

**Implementation in Tour Planner:**

- **Model**: Represents the data structures (e.g., Tour, TourLog) used in the application.
- **View**: Consists of XAML files that define the UI layout and bindings.
- **ViewModel**: Contains the business logic and handles data binding between the Model and the View.



#### unit testing decisions

In the `MappingProfileTests` class, unit tests are structured to verify the accuracy of AutoMapper mappings between various entity and model classes. The tests ensure that configurations are valid, and each property of mapped objects is correctly transferred. The `TourServiceTests` and `TourLogServiceTests` classes verify that the service methods interact correctly with the repositories and accurately perform CRUD operations on tour and tour log entities, respectively. These tests mock repository dependencies to isolate and test the business logic of the service methods. The overall approach ensures that mappings and service methods are robust, correctly implemented, and meet the expected behaviors.



#### unique feature

We have implemented a page for a car rental service where users can choose between three different car models. Depending on the model, the price varies, being either more expensive or cheaper. Users can select the rental period by choosing the start and end dates for the rental.
