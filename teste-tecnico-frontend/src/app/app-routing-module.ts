import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListarEmpresas } from './componentes/listar-empresas/listar-empresas';
import { CadastrarEmpresa } from './componentes/cadastrar-empresa/cadastrar-empresa';
import { EditarEmpresa } from './componentes/editar-empresa/editar-empresa';
import { ExcluirEmpresa } from './componentes/excluir-empresa/excluir-empresa';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'listarEmpresas',
    pathMatch: 'full'
  },
  {
    path: 'listarEmpresas',
    component: ListarEmpresas
  },
  {
    path: 'cadastrarEmpresa',
    component: CadastrarEmpresa
  },
  {
    path: 'editarEmpresa/:id',
    component: EditarEmpresa
  },
  {
    path: 'excluirEmpresa/:id',
    component: ExcluirEmpresa
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
