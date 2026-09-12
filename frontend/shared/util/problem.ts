import { HttpErrorResponse } from '@angular/common/http';
import { ProblemDetails } from '../api/models';

/** Extrae un mensaje legible de un error del API (ProblemDetails RFC 7807 o errores de validacion). */
export function problemMessage(error: unknown, fallback = 'Algo salio mal. Intenta de nuevo.'): string {
  if (error instanceof HttpErrorResponse) {
    const problem = error.error as ProblemDetails | string | null;
    if (typeof problem === 'string' && problem.trim()) return problem;
    if (problem && typeof problem === 'object') {
      if (problem.errors) {
        const first = Object.values(problem.errors)[0];
        if (first && first.length) return first[0];
      }
      if (problem.detail) return problem.detail;
      if (problem.title) return problem.title;
    }
    if (error.status === 0) return 'No se puede contactar el servidor. Esta corriendo el API?';
  }
  return fallback;
}