import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-calcularcdb',
  templateUrl: './calcularcdb.component.html',
  styleUrls: ['./calcularcdb.component.scss']
})
export class CalcularcdbComponent implements OnInit {
  
  calculocdbForm = this.formBuilder.group({
    email: ['', [Validators.email, Validators.required]],
    password: ['', [Validators.required]]
  })
  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
  }

  onSubmit(){
    if(this.calculocdbForm.invalid){
      return;
    }
    console.info("Formulario valido!")
  }

  get controls(): {[p: string]: AbstractControl}{
    return this.calculocdbForm.controls;
  }

}
