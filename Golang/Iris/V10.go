package main

import (
	"github.com/kataras/iris/v10"
)

func main() {
	app := iris.New()

	app.Get("/", func(ctx iris.Context) {
		ctx.WriteString("Hello from the server")
	})

	app.Get("/mypath", func(ctx iris.Context) {
		ctx.WriteString("Hello from " + ctx.Path())
	})

	// Run the server 
