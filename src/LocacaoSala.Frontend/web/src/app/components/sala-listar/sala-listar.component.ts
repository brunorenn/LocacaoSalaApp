import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { SalaViewModel } from '../../models/sala.vm';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sala-listar',
  templateUrl: './sala-listar.component.html',
  styleUrls: ['./sala-listar.component.css']
})
export class SalaListarComponent implements OnInit {
  public title: string = 'Locação Sala App';
  public dtOptions: DataTables.Settings = {};
  public dtTrigger: Subject<any> = new Subject();

  public salas: SalaViewModel[];

  constructor(private http: HttpClient,
              private router: Router) { }

  ngOnInit() {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10
    };
    
    this.loadTable();
  }

  loadTable(): void {
    this.http.get(environment.apiHost + 'v1/Sala')
    .toPromise()
    .then((res: any) => {
      this.salas = res as SalaViewModel[];
      this.dtTrigger.next();
    })
    .catch((error: any) => {
      window.alert(error);
    });
  }

  editar(id: string){
    this.router.navigate(['/sala-editar', id]);
  }

  excluir(id: string){
    this.http.delete(environment.apiHost + 'v1/Sala/'+ id)
    .toPromise()
    .then((res: any) => {
      window.alert('Sala excluida com sucesso');
      window.location.reload();
    })
    .catch((error: any) => {
      window.alert(error);
    });
  }

  incluir(){
    this.router.navigate(['/sala-cadastrar']);
  }
}
