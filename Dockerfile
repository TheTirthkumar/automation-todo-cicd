# Use official Playwright .NET image
FROM mcr.microsoft.com/playwright/dotnet:v1.58.0-jammy
# Set working directory
WORKDIR /app

# Copy project files
COPY . .

# Restore dependencies
RUN dotnet restore

# Build project
RUN dotnet build

# Run tests
CMD ["dotnet", "test"]

