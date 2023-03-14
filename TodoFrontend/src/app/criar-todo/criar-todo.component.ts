import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-criar-todo',
  templateUrl: './criar-todo.component.html',
  styleUrls: ['./criar-todo.component.css']
})
export class CriarTodoComponent implements OnInit {
  @Output() criarTodo: EventEmitter<any> = new EventEmitter();

  descricao: string = ``;

  constructor() { }

  ngOnInit(): void {

  }

  onSubmit() {
    const todoItem = {
      descricao: this.descricao
    }

    this.criarTodo.emit(todoItem);
  }
}
