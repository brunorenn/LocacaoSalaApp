import { Component, OnInit } from '@angular/core';
import { Sala } from '../../entities/sala';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-sala-cadastrar',
  templateUrl: './sala-cadastrar.component.html',
  styleUrls: ['./sala-cadastrar.component.css']
})
export class SalaCadastrarComponent implements OnInit {

  constructor(private http: HttpClient, private router: Router,
    private activatedRoute: ActivatedRoute) {
      
      this.activatedRoute.params.subscribe(params => {
        this.model.Id = params['id'];

        if(this.model.Id){
          this.http.get(environment.apiHost + 'v1/Sala/' + this.model.Id)
          .toPromise()
          .then(res => {
            this.model = res as Sala;
          })
          .catch(error => {
            window.alert(error);
          });
        }
      });
    }

  public model: Sala = new Sala();

  ngOnInit() {
  }

  public salvar(){
    const result = (this.model.Id) 
                  ? this.http.put(environment.apiHost + 'v1/Sala', this.model).toPromise()
                  : this.http.post(environment.apiHost + 'v1/Sala', this.model).toPromise() 

    result
    .then((res: any) => {
      window.alert("Sala incluida com sucesso");
      this.router.navigate(['']);
    })
    .catch((error)=> {
      window.alert(error.data);
    });
  }

}
