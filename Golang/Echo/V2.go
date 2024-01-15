package main

import (
	"net/http"

	"github.com/labstack/echo/v2"
)

func main() {
	// Create a new Echo instance
	e := echo.New()

	// Define a route for handling GET requests to the root path
	e.GET("/", func(c echo.Context) error {
		return c.String(http.StatusOK, "Hello, Echo v2!")
	})

	// Start the server and listen on port 8080
	e.Start(":8080")
}
