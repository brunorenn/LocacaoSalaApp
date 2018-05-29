import { RouterModule, Routes } from '@angular/router';
import { SalaListarComponent } from './components/sala-listar/sala-listar.component';
import { ModuleWithProviders } from '@angular/core';
import { SalaCadastrarComponent } from './components/sala-cadastrar/sala-cadastrar.component';

export const AppRoutes: Routes = [
    {path: '', component: SalaListarComponent },
    {path: 'sala-editar/:id', component: SalaCadastrarComponent},
    {path: 'sala-cadastrar', component: SalaCadastrarComponent}
];

export const ROUTING: ModuleWithProviders = RouterModule.forRoot(AppRoutes);