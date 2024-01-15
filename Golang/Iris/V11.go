package main

import (
	"net/http"

	"github.com/kataras/iris/v11"
)

func main() {
	app := iris.New()

	app.Get("/", func(ctx iris.Context) {
		ctx.Writef("Hello from the server")
	})

	app.Get("/mypath", func(ctx iris.Context) {
		ctx.Writef("Hello from %s", ctx.Path())
	})

	// Create our custom server and assign the Handler/Router
	srv := &http.Server{Handler: app, Addr: ":8080"}
	// http://localhost:8080/
	// http://localhost:808
