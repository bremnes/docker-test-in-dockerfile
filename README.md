# docker-test-in-dockerfile [![Build status](https://ci.appveyor.com/api/projects/status/wvqlvh5epi0lvwum?svg=true)](https://ci.appveyor.com/project/larskristianbremnes/docker-test-in-dockerfile)

.net core project to explore the possibility of running tests as a part of docker build process. By doing it this way there will be no dependencies to specific test runner(s) on the build server, only Docker.

Since there's currently no Docker support for exporting files out from a multi-stage docker build and/or image, the build script places the test results into the container and then later creates a container in which we can copy it from.

## Dockerfile
Example Dockerfile can be located at [src/CalculatorWeb/Dockerfile](src/CalculatorWeb/Dockerfile)

#### Trigger failure
This example is a simple .net core project consisting of a web api project and a separate project for unit tests. For triggering the tests to fail, add `--build-arg FAILTEST=true` to the `docker build` command. This will pass an environment variable to the unit test which will then promptly fail.

### TODO
- [x] Export test results out from build process.
  - [x] Support for AppVeyor at [appveyor.yml](appveyor.yml)
  - [x] Support for VSTS yaml ci build at [vsts.yml](vsts.yml)
