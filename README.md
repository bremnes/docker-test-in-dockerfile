# docker-test-in-dockerfile [![Build status](https://ci.appveyor.com/api/projects/status/wvqlvh5epi0lvwum?svg=true)](https://ci.appveyor.com/project/larskristianbremnes/docker-test-in-dockerfile)

Test project to explore the possibility of running tests as a part of docker build process. By doing it this way there will be no dependencies to specific test runner(s) on the build server, only docker.

## .net core
This example is a simple .net core project consisting of a web api project and a separate project for unit tests. For triggering the tests to fail, add `--build-arg FAILTEST=true` to the `docker build` command. This will pass an environment variable to the unit test which will then promptly fail.

## Dockerfile
Example Dockerfile can be located at [src/CalculatorWeb/Dockerfile](src/CalculatorWeb/Dockerfile)

### Future
- [ ] Export test results out from build process. Currently not easily supported in Docker without spinning up a container.
