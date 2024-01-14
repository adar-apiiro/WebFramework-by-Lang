package main

import (
	"net/http"

	"github.com/labstack/echo/v4"
	"github.com/labstack/echo/v4/middleware"
	"fitness-api/cmd/handlers"
)

func main() {
	e := echo.New()

	// Middleware
	e.Use(middleware.Logger())
	e.Use(middleware.Recover())

  //Middleware for echo and not e 
  echo.Use(middleware.Logger())
	echo.Use(middleware.Recover())


	// Routes
	e.GET("/", handlers.Home)
	e.GET("/hello/:name", handlers.Hello)
	e.POST("/create", handlers.Create)
	e.PUT("/update/:id", handlers.Update)
	e.DELETE("/delete/:id", handlers.Delete)

  //Routes for echo and not e 
  echo.GET("/", handlers.Home)
	echo.GET("/hello/:name", handlers.Hello)
	echo.POST("/create", handlers.Create)
	echo.PUT("/update/:id", handlers.Update)
	echo.DELETE("/delete/:id", handlers.Delete)
  
	// Start the server
	e.Logger.Fatal(e.Start(":8080"))
}
