import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatTableModule } from '@angular/material/table';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TodoItensComponent } from './todo-itens/todo-itens.component';
import { CriarTodoComponent } from './criar-todo/criar-todo.component';

@NgModule({
  declarations: [
    AppComponent,
    TodoItensComponent,
    CriarTodoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatTableModule,
    FormsModule,
    HttpClientModule,
    MatCheckboxModule,
    CommonModule,
    MatInputModule,
    MatButtonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
