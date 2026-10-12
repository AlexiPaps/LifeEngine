# Decisions

- **Time:** continuous time in years, exact age; RK4 uses a fixed monthly step (h = 1/12).
- **Basis:** parameters are illustrative (mortality: G82 Makeham), not a regulatory basis.
- **No numerical libraries:** RK4 is implemented and tested explicitly.