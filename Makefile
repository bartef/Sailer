.DEFAULT_GOAL := help

help: 
	@awk 'BEGIN {FS = ":.*##"; printf "\nUsage:\n  make \033[36m<target>\033[0m\n"} /^[a-zA-Z_\-0-9]+:.*?##/ { printf "  \033[36m%-22s\033[0m %s\n", $$1, $$2 } /^##@/ { printf "\n\033[1m%s\033[0m\n", substr($$0, 5) } ' $(MAKEFILE_LIST)

##@ Development
run: ##Run localhost
	dotnet run --project Api/Api.csproj; 
	
restore: ##Restore all projects
	dotnet restore Api/Api.csproj;
	dotnet restore Application/Application.csproj;
	dotnet restore Core/Core.csproj;
	dotnet restore Infrastructure/Infrastructure.csproj;
	dotnet restore UnitTest/UnitTest.csproj;
