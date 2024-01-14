// main.go

package main

import (
	"github.com/astaxie/beego"
)

func main() {
	beego.Router("/api/users", &UserController{})
	beego.Run()
}

// UserController handles API requests related to users.
type UserController struct {
	beego.Controller
}

// Get handles GET requests to retrieve a list of users.
func (u *UserController) Get() {
	users := []string{"user1", "user2", "user3"}
	u.Data["json"] = users
	u.ServeJSON()
}

// Post handles POST requests to create a new user.
func (u *UserController) Post() {
	// Logic to create a new user (not implemented in this example).
	u.Data["json"] = map[string]string{"message": "User created successfully"}
	u.ServeJSON()
}

// Put handles PUT requests to update an existing user.
func (u *UserController) Put() {
	// Logic to update an existing user (not implemented in this example).
	u.Data["json"] = map[string]string{"message": "User updated successfully"}
	u.ServeJSON()
}

// Delete handles DELETE requests to delete an existing user.
func (u *UserController) Delete() {
	// Logic to delete an existing user (not implemented in this example).
	u.Data["json"] = map[string]string{"message": "User deleted successfully"}
	u.ServeJSON()
}
