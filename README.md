# KeyValueStore

## Features

- Create a key-value store database
- Generate hash map every time an application starts
- Write data to the database file
- Read data from the database file

## Requirements

* Docker ✅

## How to run
1. Clone the project using the  following command **or** download the repository zip file
`git clone https://github.com/elit0451/KeyValueStore.git`
1. Using a shell navigate to the folder where the repository is located
1. Run the following command
`docker run -it --rm -v $(pwd):/src -w /src/KeyValueStore elit0452/dotnet sh -c "dotnet build”`
	-  In case you don't have the image downloaded, it will be downloaded from  Docker hub 🐳. The library will be built afterwards 📙

	NB! If you have *Windows*, please replace **$(pwd)** with the path to the directory of the repository
1. The next step is to execute the following
`docker run -it --rm -v $(pwd):/src -w /src/ClientWrite elit0452/dotnet sh -c "dotnet run"`
	-  The program for writing to a *simple_db file* will be started
1. In order to see the entries in the file you can run 👍🏻
`docker run -it --rm -v $(pwd):/src -w /src/ClientRead elit0452/dotnet sh -c "dotnet run"`
