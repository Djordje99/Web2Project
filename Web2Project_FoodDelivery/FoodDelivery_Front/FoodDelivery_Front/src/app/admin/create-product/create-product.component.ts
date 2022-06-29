import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css']
})
export class CreateProductComponent implements OnInit {

  constructor(private formBuilder: FormBuilder) { }

  form = this.formBuilder.group({
    name: ['', {
      validators: [Validators.required]
    }],
    price: ['', {
      validators: [Validators.required, Validators.min(0), Validators.max(999)]
    }],
    ingredients: ['', {
      validators: [Validators.required, Validators.minLength(10), Validators.maxLength(150)]
    }]
  });

  ngOnInit(): void {
  }

  createProduct(){
    console.log(this.form.controls['name'].value)
    console.log(this.form.controls['price'].value)
    console.log(this.form.controls['ingredients'].value)
  }

}
