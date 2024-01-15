package main

import (
	"net/http"

	"github.com/kataras/iris/v9"
)

func main() {
	app := iris.New()

	app.Get("/", func(ctx iris.Context) {
		ctx.WriteString("Hello from the server")
	})

	app.Get("/mypath", func(ctx iris.Context) {
		ctx.WriteString("Hello from " + ctx.Path())
	})

	// Run the server on port 8080
	app.Run(iris.Addr(":8080"))
}
