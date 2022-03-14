![Build](https://github.com/falberthen/pokedex/actions/workflows/pokedex.yml/badge.svg)
[![License](https://img.shields.io/github/license/falberthen/pokedex.svg)](LICENSE)

# Pokédex - .NET, GraphQL, and Vue

<p align="center">
  <br />
<img src="https://github.com/falberthen/Pokedex/blob/master/src/pokedex.spa/src/assets/pokedex-logo.png?raw=true"/>
</p>

Pokédex is my showcase of building a GraphQL based API with .NET 6 and, consuming it from a lightweight SPA built with Vue 3 and Apollo, which will allow you to perform queries for listing, 
creating and updating Pokémon in a SQLite database. 

You can learn more about the project through a series of articles on my <a href="https://falberthen.github.io/posts/pokedex-pt1/" target="_blank">blog</a>.

<br>

## Screenshots

<img src="https://github.com/falberthen/Pokedex/blob/master/src/pokedex.spa/images/pokedex.png?raw=true" target="_blank"/>

#### Subscription

<img src="https://github.com/falberthen/Pokedex/blob/master/src/pokedex.spa/images/pokedex-subscription.png" target="_blank"/>
<img src="https://github.com/falberthen/Pokedex/blob/master/src/pokedex.spa/images/animation.gif" target="_blank"/>

<br/>

## Architecture 
    
### Domain
This is where the domain models and business logic are defined. You may understand a bit more about the Pokémon domain by reading the code and understanding how the smaller pieces compose the aggregate.
<br/>

### Domain SeedWork
It defines the domain building blocks, such as entities, value objects, aggregate root, repositories, domain services and so on.
<br/>

### Api
A .NET 6 minimal API implementing GraphQL server and its Queries, Mutations, and Subscriptions. It's in charge of using the infrastructure to perform database operations and return mapped results to the client.
<br/>

### Infrastructure
Implements the database configuration and domain repositories. Also contains the `PokedexDb` SQLite database with the 151 first Pokémon and their data for you to play.
<br/>

<br>

## Technologies used

Back-end
<ul>
	<li><a href='https://dotnet.microsoft.com/en-us/download/dotnet/6.0' target="_blank">.NET 6</a> and 
	<a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx' target="_blank">C# 10</a></li>
	<li>ASP.NET minimal API</li>
	<li>Entity Framework Core 6</li>  
	<li>Automapper</li>
	<li>HotChocolate</li>
</ul>
<br>
Front-end
<ul>
	<li>
		<a href='https://vuejs.org/' target="_blank">Vue 3</a> and <a href='http://www.typescriptlang.org/' target="_blank">TypeScript</a> and <a href='https://apollo.vuejs.org/' target="_blank">Vue Apollo</a>
	</li>
</ul>

<br>


## What do you need to run it

- The latest <a href="https://dotnet.microsoft.com/download" target="_blank">.NET Core SDK</a>.
- <a href='https://nodejs.org' target="_blank">NodeJs</a> for the front-end.

#### Running the GraphQL Api
    
Navigate to `Pokedex.Api` folder and run:
```console
 $ dotnet run
``` 

#### Running the Vue 3 SPA
    
Navigate to `pokedex.spa` and run for the node packages and serving the SPA on `http://localhost:8080` respectively:

```console
 $ npm install
 $ npm run serve
```
