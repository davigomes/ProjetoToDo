import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { TodoItem } from '../models/todo-item';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TodoItemService {

  apiUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getAll():Observable<TodoItem[]> {
    return this.http.get<TodoItem[]>(`${this.apiUrl}/todoItem`);
  }

  insert(todoItem: TodoItem):Observable<TodoItem> {
    return this.http.post<TodoItem>(`${this.apiUrl}/todoItem`, todoItem);
  }
}
