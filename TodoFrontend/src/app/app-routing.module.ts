import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TodoItensComponent } from './todo-itens/todo-itens.component';

const routes: Routes = [
  { path: '', component: TodoItensComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
