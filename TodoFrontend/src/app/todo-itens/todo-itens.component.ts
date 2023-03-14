import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { TodoItemService } from '../api/todo-item.service';
import { TodoItem } from '../models/todo-item';

@Component({
  selector: 'app-todo-itens',
  templateUrl: './todo-itens.component.html',
  styleUrls: ['./todo-itens.component.css']
})
export class TodoItensComponent implements OnInit {  
  displayedColumns: string[] = ['descricao', 'data', 'status'];
  dataSource = new MatTableDataSource<TodoItem>();

  constructor(private todoItemService: TodoItemService, private changeDetectorRefs: ChangeDetectorRef) { }

  ngOnInit(): void {
    this.listarTodos();
  }

  listarTodos() {
    this.todoItemService.getAll().subscribe(todoItens => {
      this.dataSource.data = todoItens;
    });
  }

  criarTodo(todoItem: TodoItem) {
    this.todoItemService.insert(todoItem).subscribe(todoItem => {
      this.listarTodos();
      console.log(this.dataSource);
    });
  }

}
