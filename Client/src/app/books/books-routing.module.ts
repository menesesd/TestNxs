import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ErrorPageComponent } from '../shared/error-page/error-page.component';
import { IndexComponent } from './pages/index/index.component';

const routes : Routes = [
  {
    path:'',
    component: IndexComponent,
    children:[
      {
        path:'buscar',
        component:IndexComponent
      },
      {
        path: '**',
        component: ErrorPageComponent
      }
    ]
  }
]



@NgModule({
  imports: [
      RouterModule.forChild(routes)
  ],
  exports:[
    RouterModule
  ]
})
export class BooksRoutingModule { }
