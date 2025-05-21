import { bootstrapApplication } from '@angular/platform-browser';
import { BookComponent } from './app/book/book.component';

bootstrapApplication(BookComponent)
  .catch(err => console.error(err));
