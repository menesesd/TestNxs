import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ErrorPageComponent } from './shared/error-page/error-page.component';

const routes: Routes = [
  {
    path:'',
    redirectTo :'books',
    pathMatch : 'full'
  },
  {
    path:'404',
    component : ErrorPageComponent
  }, 
  {
    path:'books',
    loadChildren: () => import('./books/books.module').then(m => m.BooksModule)
  },
  {
    path: '**',
    redirectTo: '404'
  }, 

]

@NgModule({
 
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports:[
    RouterModule
  ]
})
export class AppRoutingModule { }
