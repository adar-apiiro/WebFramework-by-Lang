package main

import (
	"net/http"
	"github.com/labstack/echo/v3"
	"github.com/labstack/echo/v3/middleware"
)

func main() {
	// Create an Echo instance
	e := echo.New()

	// Middleware
	e.Use(middleware.Logger())
	e.Use(middleware.Recover())

	// Define routes
	e.GET("/", func(c echo.Context) error {
		return c.String(http.StatusOK, "Hello, Echo v3!")
	})

	e.POST("/api/resource", func(c echo.Context) error {
		return c.String(http.StatusCreated, "Resource created!")
	})

	// Start the server
	e.Start(":8080")
}
