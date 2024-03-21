import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatToolbarModule } from '@angular/material/toolbar';
import { RouterOutlet } from '@angular/router';
import { Observable } from 'rxjs';
import { ConversionResponse, WordToNumberService } from './word-to-number.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule,
    ReactiveFormsModule, MatCardModule, MatToolbarModule,
    MatButtonModule, MatIconModule, MatFormFieldModule, MatInputModule,],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'K L A';
  response$?: Observable<null | ConversionResponse>;

  constructor(private formBuilder: FormBuilder,
    private wordToNumberService: WordToNumberService) { }

  frm = this.formBuilder.group({
    userInput: new FormControl('99 999,09', [
      Validators.required,
      Validators.minLength(1),
      // Validators.pattern('^[0-9 ,]*$')
    ]),
  })

  convertToWord() {
    this.response$ = this.wordToNumberService.getConvert(this.frm.controls.userInput.value!.toString());
    console.info(this.frm.controls.userInput.value);
  }
}
