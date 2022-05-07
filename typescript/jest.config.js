const { resolve } = require("path");

module.exports = {
  preset: "ts-jest",
  testEnvironment: "node",
  collectCoverageFrom: ["src/**/*.ts"],
  moduleDirectories: ["node_modules", "src"],
  moduleNameMapper: {
    "@/(.*)": resolve(__dirname, "./src/$1"),
  },
};
