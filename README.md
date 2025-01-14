# PC Builder

Welcome to the **PC Builder** repository! This project is designed to help users customize and build their dream PC by selecting compatible components tailored to their preferences and needs. Built using **.NET Core**, **MVC**, and following the principles of **Clean Architecture**, the application ensures modular, scalable, and maintainable code.

## Features

- **Component Compatibility Check**: Ensures selected components (CPU, GPU, Motherboard, RAM, etc.) are compatible.
- **Customizable Builds**: Create builds for gaming, productivity, or general use.
- **User-Friendly Interface**: Simple and intuitive design for effortless navigation.
- **Performance Estimation**: Predict the system's performance based on selected components.
- **Price Comparison**: View pricing from multiple vendors to make cost-effective decisions.

## Technology Stack

- **Framework**: .NET Core
- **Design Pattern**: Model-View-Controller (MVC)
- **Architecture**: Clean Architecture for maintainable and testable code
- **Database**: SQL Server
- **Frontend**: ASP.NET MVC

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/djunaid/PC-Builder.git
   ```
2. Navigate to the project directory:
   ```bash
   cd PC-Builder
   ```
3. Build and run the application:
   ```bash
   dotnet build
   dotnet run
   ```

## Project Structure

This project follows the **Clean Architecture** principles:
- **Core**: Contains domain entities, interfaces, and business rules.
- **Application**: Handles application logic, use cases, and service contracts.
- **Infrastructure**: Implements database access, external services, and other system integrations.
- **UI**: Contains the MVC components (Controllers, Views, and frontend resources).

## Contributing

Contributions are welcome! If you’d like to contribute, please:
1. Fork the repository.
2. Create a feature branch:
   ```bash
   git checkout -b feature/YourFeatureName
   ```
3. Commit your changes:
   ```bash
   git commit -m "Add YourFeatureName"
   ```
4. Push to the branch:
   ```bash
   git push origin feature/YourFeatureName
   ```
5. Open a pull request.

## License

This project is licensed under the [MIT License](LICENSE).

## Contact

For questions or suggestions, feel free to reach out:
- **Author**: Junaid
- **GitHub**: [djunaid](https://github.com/djunaid)
