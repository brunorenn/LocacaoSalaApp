import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { SalaListarComponent } from './components/sala-listar/sala-listar.component';
import { ROUTING } from './app.routing';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { DataTablesModule } from 'angular-datatables';
import { SalaInterceptorService } from './services/sala-interceptor.service';
import { SalaCadastrarComponent } from './components/sala-cadastrar/sala-cadastrar.component';

@NgModule({
  declarations: [
    AppComponent,
    SalaListarComponent,
    SalaCadastrarComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    DataTablesModule,
    HttpClientModule,
    ROUTING
  ],
  providers: [
    SalaInterceptorService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
