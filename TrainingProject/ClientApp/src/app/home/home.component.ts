import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Student } from 'src/ViewModels/student';
import { Observable } from 'rxjs';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  
  constructor(private http: HttpClient){

  }

  ngOnInit(){
    let studentList: Student[] ; 
    this.getData().pipe(first()).subscribe (res=>{
      studentList = res ; 
    }); 
    console.log(studentList); 
  }

  public getData() : Observable<Student[]> {
    let url = "http://localhost:5000/api/Student/GetStudentsList" ; 
    
    const headers = new HttpHeaders().set('content-type', 'application/json');
    return this.http.get<Student[]>(url,{headers}); 
  }

}


