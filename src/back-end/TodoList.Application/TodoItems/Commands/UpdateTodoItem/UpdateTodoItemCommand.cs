﻿using MediatR;
using TodoList.Application.Common.Errors;

namespace TodoList.Application.TodoItems.Commands.UpdateTodoItem
{
    public sealed record UpdateTodoItemCommand(Guid Id, string Description, bool IsCompleted ) 
        : IRequest<TodoItemResult<ApplicationError, UpdateTodoItemResponse>>;
}
