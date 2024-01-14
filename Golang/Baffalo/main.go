package actions

import (
	"github.com/gobuffalo/buffalo"
	"github.com/gobuffalo/pop"
	"github.com/pkg/errors"
)

// TodoResource is the resource for the Todo model.
type TodoResource struct {
	buffalo.Resource
}

// List gets all Todo items.
func (v TodoResource) List(c buffalo.Context) error {
	tx := c.Value("tx").(*pop.Connection)
	todos := &Todo{}
	q := tx.Q().Order("created_at DESC")
	if err := q.All(todos); err != nil {
		return errors.WithStack(err)
	}

	return c.Render(200, r.JSON(todos))
}

// Show gets the data for one Todo item.
func (v TodoResource) Show(c buffalo.Context) error {
	tx := c.Value("tx").(*pop.Connection)
	todo := &Todo{}
	if err := tx.Find(todo, c.Param("todo_id")); err != nil {
		return c.Error(404, err)
	}

	return c.Render(200, r.JSON(todo))
}

// Create adds a Todo item to the database.
func (v TodoResource) Create(c buffalo.Context) error {
	todo := &Todo{}
	if err := c.Bind(todo); err != nil {
		return errors.WithStack(err)
	}

	tx := c.Value("tx").(*pop.Connection)
	if err := tx.Create(todo); err != nil {
		return errors.WithStack(err)
	}

	return c.Render(201, r.JSON(todo))
}

// Update changes a Todo item in the database.
func (v TodoResource) Update(c buffalo.Context) error {
	tx := c.Value("tx").(*pop.Connection)
	todo := &Todo{}
	if err := tx.Find(todo, c.Param("todo_id")); err != nil {
		return c.Error(404, err)
	}

	if err := c.Bind(todo); err != nil {
		return errors.WithStack(err)
	}

	if err := tx.Update(todo); err != nil {
		return errors.WithStack(err)
	}

	return c.Render(200, r.JSON(todo))
}

// Destroy deletes a Todo item from the database.
func (v TodoResource) Destroy(c buffalo.Context) error {
	tx := c.Value
